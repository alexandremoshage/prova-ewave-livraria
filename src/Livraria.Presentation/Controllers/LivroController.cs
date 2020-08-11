using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.RetornoRequest;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Livraria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {

        private readonly ILivroService _livroService;
        private readonly IUsuarioService _usuarioService;

        public LivroController(ILivroService livroService, IUsuarioService usuarioService)
        {
            _livroService = livroService;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IEnumerable<Livro> Get()
        {
            return this._livroService.ObertTodos();
        }


        [HttpGet("emprestar")]
        public IEnumerable<Livro> ObterTodosEmprestar()
        {
            return this._livroService.ObertParaEmprestar();
        }

        [HttpGet("{idUsuario:int}/devolver")]
        public IEnumerable<Livro> ObterTodosDevelover(int idUsuario)
        {
            return this._livroService.ObertParaDevolver(idUsuario);
        }

        [HttpGet("{id:int}")]
        public Livro Get(int id)
        {
            return this._livroService.GetById(id);
        }
        [HttpPut("{id:int}")]
        public Retorno Alterar(int id, [FromBody] LivroDto dto)
        {
            var retorno = new Retorno();
            retorno.Id = id;
            var InstituicaoDeEnsino = _livroService.GetById(id);
            if (InstituicaoDeEnsino == null)
            {
                retorno.ListaErros.Add("Instituição não encontrada");
                return retorno;
            }
            var livro = _livroService.GetById(id);
            livro.Genero = dto.Genero;
            livro.Publicacao = dto.Publicacao;
            livro.Paginas = dto.Paginas;
            livro.Autor = dto.Autor;
            livro.Editora = dto.Editora;
            livro.Descricao = dto.Descricao;
            livro.Titulo = dto.Titulo;
            _livroService.Update(livro);
            retorno.ListaErros = livro.ListaErros;
            return retorno;
        }

        [HttpPut("{idLivro:int}/usuario/{idUsuario:int}/emprestar")]
        public Retorno EmprestarLivro(int idLivro, int idUsuario)
        {
            var retorno = new Retorno();
            var livro = _livroService.GetById(idLivro);
            var usuario = _usuarioService.GetById(idUsuario);
            if (livro == null)
            {
                retorno.ListaErros.Add("Livro não encontrado");
                return retorno;
            }
            if (usuario == null)
            {
                retorno.ListaErros.Add("Usuário não encontrado");
                return retorno;
            }

            var entidade = _livroService.Emprestar(livro, usuario);
            retorno.Id = entidade.Id;
            retorno.ListaErros = entidade.ListaErros;
            return retorno;
        }

        [HttpPut("{idLivro:int}/usuario/{idUsuario:int}/devolver")]
        public Retorno Devolver(int idLivro, int idUsuario)
        {
            var retorno = new Retorno();
            var livro = _livroService.GetById(idLivro);
            var usuario = _usuarioService.GetById(idUsuario);
            if (livro == null)
            {
                retorno.ListaErros.Add("Livro não encontrado");
                return retorno;
            }
            if (usuario == null)
            {
                retorno.ListaErros.Add("Usuário não encontrado");
                return retorno;
            }

            var entidade = _livroService.Devolver(livro, usuario);
            retorno.Id = entidade.Id;
            retorno.ListaErros = entidade.ListaErros;
            return retorno;
        }
        [HttpPut("{idLivro:int}/usuario/{idUsuario:int}/reservar")]
        public Retorno ReservarLivro(int idLivro, int idUsuario)
        {
            var retorno = new Retorno();
            var livro = _livroService.GetById(idLivro);
            var usuario = _usuarioService.GetById(idUsuario);
            if (livro == null)
            {
                retorno.ListaErros.Add("Livro não encontrado");
                return retorno;
            }
            if (usuario == null)
            {
                retorno.ListaErros.Add("Usuário não encontrado");
                return retorno;
            }

            var entidade = _livroService.Reservar(livro, usuario);
            retorno.Id = entidade.Id;
            retorno.ListaErros = entidade.ListaErros;
            return retorno;
        }

        [HttpDelete("{id:int}")]
        public Retorno Deletar(int id)
        {
            var retorno = new Retorno();
            var livro = _livroService.GetById(id);
            if (livro == null)
            {
                retorno.ListaErros.Add("Livro não encontrado");
                return retorno;
            }
            _livroService.Delete(livro);

            retorno.ListaErros = livro.ListaErros;
            retorno.Id = livro.Id;
            return retorno;
        }

        [HttpPost]
        public Retorno Cadastra([FromBody] LivroDto dto)
        {
            var livro = new Livro();
            livro.Genero = dto.Genero;
            livro.Publicacao = dto.Publicacao;
            livro.Paginas = dto.Paginas;
            livro.Autor = dto.Autor;
            livro.Editora = dto.Editora;
            livro.Descricao = dto.Descricao;
            livro.Titulo = dto.Titulo;
            _livroService.Save(livro);
            return new Retorno
            {
                ListaErros = livro.ListaErros,
                Id = livro.Id
            };
        }
    }
}
