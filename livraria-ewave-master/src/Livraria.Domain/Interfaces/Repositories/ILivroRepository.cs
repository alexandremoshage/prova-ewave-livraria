using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Repositories
{
    public interface ILivroRepository : IRepositoryBase<Livro>
    {

        IEnumerable<Livro> GetAll();

        IEnumerable<Livro> GetParaEmprestar();

        IEnumerable<Livro> GetParaDevolver(int idUsuario);

        IEnumerable<Livro> GetByFilter(string filtro);
        Livro GetById(int Id);

    }
}
