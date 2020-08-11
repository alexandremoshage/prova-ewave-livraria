using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.Infra.Data.Repositories
{
    public class UsuarioLivroEmprestadoRepository : RepositoryBase<UsuarioLivroEmprestado>, IUsuarioLivroEmprestadoRepository
    {

        public UsuarioLivroEmprestadoRepository(LivrariaContext context)
            : base(context)
        { }

        public IEnumerable<UsuarioLivroEmprestado> GetAll()
        {
            var dados = _Context.UsuarioLivroEmprestado.ToList();
            return dados;
        }

        public UsuarioLivroEmprestado GetById(int id)
        {
            var dados = _Context.UsuarioLivroEmprestado.FirstOrDefault(p => p.Id == id);
            return dados;
        }

    }
}
