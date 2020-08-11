using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.UnitOfWork
{
    public interface IUnitOfWork
    { 
        void Commit();
        bool Sucesso();
    }
}
