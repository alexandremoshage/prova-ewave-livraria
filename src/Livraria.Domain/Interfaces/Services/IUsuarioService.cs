using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        IEnumerable<Usuario> ObertTodos();
        Usuario GetById(int id);

    }
}
