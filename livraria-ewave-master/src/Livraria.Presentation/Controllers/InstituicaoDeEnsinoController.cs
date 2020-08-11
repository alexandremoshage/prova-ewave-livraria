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
    public class InstituicaoDeEnsinoController : ControllerBase
    {
        private readonly IInstituicaoDeEnsinoService _instituicaoDeEnsinoService;
        public InstituicaoDeEnsinoController(IInstituicaoDeEnsinoService instituicaoDeEnsinoService)
        {
            _instituicaoDeEnsinoService = instituicaoDeEnsinoService;
        }

        [HttpGet]
        public IEnumerable<InstituicaoDeEnsino> Get()
        {
            return this._instituicaoDeEnsinoService.ObertTodos();
        }

        [HttpGet("{id:int}")]
        public InstituicaoDeEnsino Get(int id)
        {
            return this._instituicaoDeEnsinoService.GetById(id);
        }

        [HttpPut("{id:int}")]
        public Retorno Alterar(int id, [FromBody] InstituicaoDeEnsinoDto dto)
        {
            var retorno = new Retorno();
            retorno.Id = id;
            var InstituicaoDeEnsino = _instituicaoDeEnsinoService.GetById(id);
            if (InstituicaoDeEnsino == null)
            {
                retorno.ListaErros.Add("Instituição não encontrada");
            }
            InstituicaoDeEnsino.Nome = dto.Nome;
            InstituicaoDeEnsino.Endereco = dto.Endereco;
            InstituicaoDeEnsino.CNPJ = dto.CNPJ;
            InstituicaoDeEnsino.Endereco = dto.Endereco;
            retorno.ListaErros = InstituicaoDeEnsino.ListaErros;
            _instituicaoDeEnsinoService.Update(InstituicaoDeEnsino);
            return retorno;
        }

        [HttpDelete("{id:int}")]
        public Retorno Deletar(int id)
        {
            var retorno = new Retorno();
            retorno.Id = id;
            var InstituicaoDeEnsino = _instituicaoDeEnsinoService.GetById(id);
            _instituicaoDeEnsinoService.Delete(InstituicaoDeEnsino);
            if (InstituicaoDeEnsino == null)
            {
                retorno.ListaErros.Add("Instituição não encontrada");
            }
            retorno.ListaErros = InstituicaoDeEnsino.ListaErros;
            return retorno;
        }

        [HttpPost]
        public Retorno Cadastra([FromBody] InstituicaoDeEnsinoDto dto)
        {
            var InstituicaoDeEnsino = new InstituicaoDeEnsino();
            InstituicaoDeEnsino.Nome = dto.Nome;
            InstituicaoDeEnsino.CNPJ = dto.CNPJ;
            InstituicaoDeEnsino.Endereco = dto.Endereco;
            _instituicaoDeEnsinoService.Save(InstituicaoDeEnsino);
            return new Retorno
            {
                ListaErros = InstituicaoDeEnsino.ListaErros,
                Id = InstituicaoDeEnsino.Id
            };
        }
    }
}
