using CVP.Domain.Models;
using CVP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CVP.Domain.Models.Auth;

namespace CVP.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Skill> Skill { get; }
        IRepository<User> User { get; }


        int SaveChanges();
    }
}
