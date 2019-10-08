using CVP.Domain.Models;
using CVP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Skill> Skill { get; }


        int SaveChanges();
    }
}
