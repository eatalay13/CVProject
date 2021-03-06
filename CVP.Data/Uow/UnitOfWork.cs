﻿using CVP.Domain.Models;
using CVP.Data.Repository;
using CVP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CVP.Domain.Models.Auth;

namespace CVP.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CVProjectContext _dbContext;
        private readonly Lazy<IRepository<Skill>> _skill;
        private readonly Lazy<IRepository<User>> _user;

        public IRepository<Skill> Skill => _skill.Value;
        public IRepository<User> User => _user.Value;

        public UnitOfWork(CVProjectContext context)
        {
            _dbContext = context;

            if (context == null)
            {
                throw new ArgumentNullException("Db Context Can Not Be Null");
            }

            _skill = CreateRepo<Skill>();
            _user = CreateRepo<User>();
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
