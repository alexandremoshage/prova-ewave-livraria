using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace Livraria.Domain.Interfaces.Services
{
   public interface IInstituicaoDeEnsinoService: IServiceBase<InstituicaoDeEnsino>
    {
        IEnumerable<InstituicaoDeEnsino> ObertTodos();
        InstituicaoDeEnsino GetById(int id);
    }
}
