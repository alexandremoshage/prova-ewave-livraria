using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Repositories
{
   public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int Id);

    }
}
