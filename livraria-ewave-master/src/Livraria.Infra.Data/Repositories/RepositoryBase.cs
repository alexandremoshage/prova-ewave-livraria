using Livraria.Domain.Interfaces.Repositories.Base;
using Livraria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        protected readonly LivrariaContext _Context;
        protected DbSet<TEntity> _DbSet;

        public RepositoryBase(LivrariaContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<TEntity>();
        }
        public TEntity Save(TEntity entity)
        {
            _DbSet.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _DbSet.Update(entity);
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            _DbSet.Remove(entity);

            //TODO: retornar valor correto
            return true;            
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
         
    }
}
