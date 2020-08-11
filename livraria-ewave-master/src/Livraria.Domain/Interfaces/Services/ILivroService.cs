using Livraria.Domain.Entities;
using Livraria.Domain.Entities.Base;
using Livraria.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Services
{
    public interface ILivroService : IServiceBase<Livro>
    {
        IEnumerable<Livro> FiltrarTitulo(string filtro);
        IEnumerable<Livro> ObertTodos();
        IEnumerable<Livro> ObertParaEmprestar();
        IEnumerable<Livro> ObertParaDevolver(int idUsuario);
        Livro GetById(int Id);
        EntityBase Emprestar(Livro livro, Usuario usuario);
        EntityBase Devolver(Livro livro, Usuario usuario);
        EntityBase Reservar(Livro livro, Usuario usuario);

    }
}
