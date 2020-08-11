using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Repositories
{
    public interface IInstituicaoDeEnsinoRepository : IRepositoryBase<InstituicaoDeEnsino>
    {
        IEnumerable<InstituicaoDeEnsino> GetAll();
        InstituicaoDeEnsino GetById(int id);

    }
}
