using Livraria.Domain.UnitOfWork;
using Livraria.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LivrariaContext _Context;
        public bool IsSucesso { get; private set; }

        public UnitOfWork(LivrariaContext context)
        {
            _Context = context;
        }

        public void Commit()
        {
            try
            {
                _Context.SaveChanges();
                IsSucesso = true;
            }
            catch (Exception)
            {

            }
              
        }

        public bool Sucesso()
        {
            return this.IsSucesso;
        }

    }
}
