using CVP.Data.Models;
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
        private readonly Lazy<IRepository<Skill>> _skill;

        public IRepository<Skill> Skill => _skill.Value;

        public UnitOfWork(CVProjectContext context)
        {
            _dbContext = context;

            if (context == null)
            {
                throw new ArgumentNullException("Db Context Can Not Be Null");
            }

            _skill = CreateRepo<Skill>();
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
