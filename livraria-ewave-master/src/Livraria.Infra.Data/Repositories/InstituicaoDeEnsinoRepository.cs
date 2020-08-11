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
    public class InstituicaoDeEnsinoRepository : RepositoryBase<InstituicaoDeEnsino>, IInstituicaoDeEnsinoRepository
    {
        public InstituicaoDeEnsinoRepository(LivrariaContext context)
            : base(context)
        { }

        public IEnumerable<InstituicaoDeEnsino> GetAll()
        {
            var dados = _Context.InstituicaoDeEnsino.ToList();
            return dados;
        }

        public InstituicaoDeEnsino GetById(int InstituicaoDeEnsinoId)
        {
            var dados = _Context.InstituicaoDeEnsino.FirstOrDefault(p => p.Id == InstituicaoDeEnsinoId);
            return dados;
        }

    }
}
