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
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {

        public LivroRepository(LivrariaContext context)
            : base(context)
        { }

        public IEnumerable<Livro> GetAll()
        {
            var dados = _Context.Livro.ToList();
            return dados;
        }


        public IEnumerable<Livro> GetParaEmprestar()
        {
            var dados = _Context.Livro.Where(x => x.Emprestado == false && x.Reservado == false);
            return dados;
        }

        public IEnumerable<Livro> GetParaDevolver(int idUsuario)
        {

            var livrosEmpresdados = _Context.UsuarioLivroEmprestado.Where(x => x.IdUsuario == idUsuario && x.Devolvido == false);
            var livos = _Context.Livro.Where(x => livrosEmpresdados.Any(y => y.IdLivro == x.Id));
            return livos;
        }

        public IEnumerable<Livro> GetByFilter(string filtro)
        {
            var dados = _Context.Livro.Where(x => x.Titulo.Contains(filtro) || x.Genero.Contains(filtro)|| x.Autor.Contains(filtro) || x.Editora.Contains(filtro));
            return dados;
        }

        public Livro GetById(int Id)
        {
            var dados = _Context.Livro.Include(x => x.UsuarioReserva).AsTracking().FirstOrDefault(p => p.Id == Id);
            return dados;
        }

    }
}
