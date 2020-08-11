using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.test.Builder
{
    public class InstituicaoDeEnsinoBuilder
    {
        public InstituicaoDeEnsino Build()
        {
            return new InstituicaoDeEnsino
            {
                Id = 1,
                Nome = "Banco do brasil",
                Endereco = "Rua das oliveiras 1990",
                CNPJ = "00360305000104"
            };
        }
    }
}
