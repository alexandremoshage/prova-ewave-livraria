using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Livraria.Infra.Data.Repositories
{
   public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(LivrariaContext context)
            : base(context)
        { }

        public IEnumerable<Usuario> GetAll()
        {
            var dados = _Context.Usuario.Include(x => x.InstituicaoDeEnsino).AsTracking().ToList();
            return dados;
        }
 
        public Usuario GetById(int id)
        {
            var dados = _Context.Usuario.Include(c => c.LivrosEmprestados).AsTracking().FirstOrDefault(p => p.Id == id);
            return dados;
        }

    }
}
