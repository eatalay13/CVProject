using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVP.Business.Interfaces;
using CVP.Domain.Contracts.Auth.Requests;
using CVP.Domain.Contracts.Auth.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVP.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusiness _authBusiness;
        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("CreateUser")]
        public async Task<CreateUserResponse> CreateUser([FromBody] CreateUserRequest request)
        {
            var IsSuccess = await _authBusiness.CreateUser(request);

            return new CreateUserResponse();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = await _authBusiness.Login(request);

            if (response == null)
            {
                HttpContext.Response.StatusCode = 401;
                return null;
            }

            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("ChangePassword")]
        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request)
        {
            ChangePasswordResponse response = await _authBusiness.ChangePassword(request);

            if (response == null)
            {
                HttpContext.Response.StatusCode = 401;
            }

            return response;
        }

        [HttpPost]
        [Route("UpdateProfile")]
        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest updateUserRequest)
        {
            return await _authBusiness.UpdateUser(updateUserRequest);
        }
    }
}