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
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<TModel> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            _dbSet.RemoveRange(entities);
        }

        public TModel GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public List<TModel> GetList()
        {
            return _dbSet.ToList();
        }

        public void Insert(TModel entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Add(entity);
        }

        public void Insert(IEnumerable<TModel> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            _dbSet.AddRange(entities);
        }

        public void Update(TModel entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
        }

        public void Update(IEnumerable<TModel> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _dbSet.UpdateRange(entities);
        }
    }
}
