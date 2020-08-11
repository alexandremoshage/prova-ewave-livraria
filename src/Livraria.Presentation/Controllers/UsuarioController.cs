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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _UsuarioService;
        public UsuarioController(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return this._UsuarioService.ObertTodos();
        }

        [HttpGet("{id:int}")]
        public Usuario Get(int id)
        {
            return this._UsuarioService.GetById(id);
        }
        [HttpPut("{id:int}")]
        public Retorno Alterar(int id, [FromBody] UsuarioDto dto)
        {
            var retorno = new Retorno();
            retorno.Id = id;
            var InstituicaoDeEnsino = _UsuarioService.GetById(id);
            if (InstituicaoDeEnsino == null)
            {
                retorno.ListaErros.Add("Usuário não encontrada");
                return retorno;
            }
            var Usuario = _UsuarioService.GetById(id);
            Usuario.Nome = dto.Nome;
            Usuario.Endereco= dto.Endereco;
            Usuario.CPF = dto.CPF;
            Usuario.Telefone = dto.Telefone;
            Usuario.Email = dto.Email;
            Usuario.IdInstituicaoDeEnsino = dto.IdInstituicaoDeEnsino;
            _UsuarioService.Update(Usuario);
            retorno.ListaErros = Usuario.ListaErros;
            return retorno;
        }
 

        [HttpDelete("{id:int}")]
        public Retorno Deletar(int id)
        {
            var retorno = new Retorno();
            var Usuario = _UsuarioService.GetById(id);
            if (Usuario == null)
            {
                retorno.ListaErros.Add("Usuario não encontrado");
                return retorno;
            }
            _UsuarioService.Delete(Usuario);
            retorno.ListaErros = Usuario.ListaErros;
            return retorno;
        }

        [HttpPost]
        public Retorno Cadastra([FromBody] UsuarioDto dto)
        {
            var Usuario = new Usuario();
            Usuario.Nome = dto.Nome;
            Usuario.Endereco = dto.Endereco;
            Usuario.CPF = dto.CPF;
            Usuario.Telefone = dto.Telefone;
            Usuario.Email = dto.Email;
            Usuario.IdInstituicaoDeEnsino = dto.IdInstituicaoDeEnsino;
            _UsuarioService.Save(Usuario);
            return new Retorno
            {
                ListaErros = Usuario.ListaErros,
                Id = Usuario.Id
            };
        }
    }
}
