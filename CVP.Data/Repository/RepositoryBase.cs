using CVP.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CVP.Data.Repository
{
    public class RepositoryBase<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TModel> _dbSet;

        public RepositoryBase(CVProjectContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }
        ~RepositoryBase()
        {
            this._context.Dispose();
        }

        public IQueryable<TModel> Table => _dbSet;

        public void Delete(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }

        public TModel GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TModel> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
