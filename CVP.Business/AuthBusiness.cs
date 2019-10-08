using CVP.Business.Interfaces;
using CVP.Data.Repository.Interfaces;
using CVP.Domain.Contracts.Auth.Requests;
using CVP.Domain.Contracts.Auth.Responses;
using CVP.Domain.Models.Auth;
using CVP.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CVP.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthBusiness(IUserRepository userRepo,
              IConfiguration config,
              SignInManager<User> signInManager,
              UserManager<User> userManager
          )
        {
            _userRepo = userRepo;
            _config = config;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.EmailAddress);
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded)
            {
                return new ChangePasswordResponse
                {
                    Message = "İşlem Başarılıdır"
                };
            }
            else
            {
                return new ChangePasswordResponse
                {
                    Message = "İşlem Sırasında Hata Oldu : " + result.Errors.Select(x => x.Description).FirstOrDefault()
                };
            }
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            var isEmailExists = await _userRepo.IsUserEMailExists(request.Email);

            if (isEmailExists)
            {
                throw new BusinessException("Bu E-Posta adresiyle daha önce kayıt olunmuş");
            }

            var result = await _userManager.CreateAsync(new User()
            {
                Email = request.Email.ToLowerInvariant(),
                LastName = request.LastName,
                Name = request.FirstName,
                UserName = request.Email.ToLowerInvariant(),
                EmailConfirmed = true,

            }, request.Password);

            if (result.Errors.Count() > 0)
            {
                throw new BusinessException(result.Errors.FirstOrDefault().Description);
            }

            return new CreateUserResponse()
            {
                IsSuccess = result.Succeeded,
                Message = "Kullanıcı Başarıyla Oluşturuldu"
            };

        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userRepo.GetUser(request.Email);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, request.Password, false);



            if (!result.Succeeded)
            {
                return null;
            }

            var claims = new[] {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
                new Claim (ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("Application:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponse()
            {
                Token = tokenHandler.WriteToken(token),
                User = new Domain.Contracts.Auth.User
                {
                    Email = user.Email,
                    LastName = user.LastName,
                    FirstName = user.Name,
                    Id = user.Id
                }
            };
        }

        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest updateUserRequest)
        {
            var response = new UpdateUserResponse();
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == updateUserRequest.Id);
                var passwordHash = _userManager.PasswordHasher.HashPassword(user, updateUserRequest.Password);
                var result = _userRepo.UpdateUser(new User
                {
                    PasswordHash = passwordHash,
                    Name = updateUserRequest.FirstName,
                    LastName = updateUserRequest.LastName
                });
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                //response.Errors.Add(ex);
            }
            return await Task.FromResult(response);
        }
    }
}
