using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    { 
        TEntity Save(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity); 

    }
}
