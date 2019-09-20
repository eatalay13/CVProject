using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {

        int SaveChanges();
    }
}
