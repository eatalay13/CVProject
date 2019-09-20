using CVP.Data.Repository;
using CVP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CVProjectContext _dbContext;
        public UnitOfWork(CVProjectContext context)
        {
            _dbContext = context;

            if (context == null)
            {
                throw new ArgumentNullException("Db Context Can Not Be Null");
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        private Lazy<IRepository<TModel>> CreateRepo<TModel>() where TModel : class
        {
            return new Lazy<IRepository<TModel>>(() => new RepositoryBase<TModel>(_dbContext));
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
