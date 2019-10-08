using CVP.Data.Repository.Interfaces;
using CVP.Data.Uow;
using CVP.Domain.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CVP.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _uow;

        public UserRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _uow.User.Table.FirstOrDefaultAsync(x => x.Email.Equals(email.ToLower()));

            if (user == null)
                return null;

            return user;
        }

        public async Task<bool> IsUserEMailExists(string email)
        {
            var isEmailExists = await _uow.User.Table.AnyAsync(x => x.Email.Equals(email.ToLower()));
            return isEmailExists;
        }

        public Task UpdateUser(User user)
        {
            _uow.User.Update(user);
            return Task.CompletedTask;
            //throw new NotImplementedException();
        }
    }
}
