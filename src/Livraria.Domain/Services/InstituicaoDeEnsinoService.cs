using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Services
{
   public class InstituicaoDeEnsinoService : IInstituicaoDeEnsinoService
    {

        private readonly IInstituicaoDeEnsinoRepository _InstituicaoDeEnsinoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InstituicaoDeEnsinoService(IInstituicaoDeEnsinoRepository InstituicaoDeEnsinoRepository, IUnitOfWork unitOfWork)
        {
            _InstituicaoDeEnsinoRepository = InstituicaoDeEnsinoRepository;
            _unitOfWork = unitOfWork;
        }

        public InstituicaoDeEnsino Save(InstituicaoDeEnsino entity)
        {
            if (!entity.Validar())
                return entity;

            if (entity.Valido)
            {
                _InstituicaoDeEnsinoRepository.Save(entity);
                _unitOfWork.Commit();
            }
            return entity;
        }

        public InstituicaoDeEnsino Update(InstituicaoDeEnsino entity)
        {
            if (!entity.Validar())
                return entity;
            if (entity.Valido)
            {
                _InstituicaoDeEnsinoRepository.Update(entity);
                _unitOfWork.Commit();
            }

            return entity;
        }

        public bool Delete(InstituicaoDeEnsino entity)
        {

            _InstituicaoDeEnsinoRepository.Delete(entity);
            _unitOfWork.Commit();
            if (!_unitOfWork.Sucesso())
                entity.AdicionaErro("Não foi possível excluir, pois o cadastrado já gerou algum outro cadastro depedente");
            return _unitOfWork.Sucesso();
        }

        public InstituicaoDeEnsino GetById(int InstituicaoDeEnsinoId)
        {
            return _InstituicaoDeEnsinoRepository.GetById(InstituicaoDeEnsinoId);
        }

        public IEnumerable<InstituicaoDeEnsino> ObertTodos()
        {
            return _InstituicaoDeEnsinoRepository.GetAll();
        }

        public void Dispose()
        {
            _InstituicaoDeEnsinoRepository.Dispose();
        }

    }
}
