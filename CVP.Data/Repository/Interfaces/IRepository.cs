using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CVP.Data.Repository.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {

        #region Methods

        TModel GetById(object id);

        void Insert(TModel entity);

        void Insert(IEnumerable<TModel> entities);

        void Update(TModel entity);

        void Update(IEnumerable<TModel> entities);

        void Delete(TModel entity);

        void Delete(IEnumerable<TModel> entities);

        #endregion

        #region Properties

        IQueryable<TModel> Table { get; }

        #endregion
    }
}
