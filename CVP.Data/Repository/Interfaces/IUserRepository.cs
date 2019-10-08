using CVP.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CVP.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsUserEMailExists(string email);
        Task<User> GetUser(string email);
        Task UpdateUser(User user);

    }
}
