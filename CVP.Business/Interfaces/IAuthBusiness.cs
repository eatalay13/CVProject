using CVP.Domain.Contracts.Auth.Requests;
using CVP.Domain.Contracts.Auth.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CVP.Business.Interfaces
{
    public interface IAuthBusiness
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request);
        Task<UpdateUserResponse> UpdateUser(UpdateUserRequest updateUserRequest);
    }
}
