using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Services.Base
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {

        TEntity Save(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);

    }
}
