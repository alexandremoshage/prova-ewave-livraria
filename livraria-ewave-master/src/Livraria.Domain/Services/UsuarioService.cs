using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IInstituicaoDeEnsinoRepository _InstituicaoDeEnsinoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IInstituicaoDeEnsinoRepository InstituicaoDeEnsinoRepository, IUsuarioRepository UsuarioRepository, IUnitOfWork unitOfWork)
        {
            _InstituicaoDeEnsinoRepository = InstituicaoDeEnsinoRepository;
            _UsuarioRepository = UsuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public Usuario Save(Usuario entity)
        {
            if (!entity.Validar())
                return entity;

            if (entity.Valido)
            {
                if (_InstituicaoDeEnsinoRepository.GetById(entity.IdInstituicaoDeEnsino) == null)
                {
                    entity.ListaErros.Add("Instituicao de ensino não encontrada");
                }
                else
                {
                    _UsuarioRepository.Save(entity);
                    _unitOfWork.Commit();
                }
            }
            return entity;
        }

        public Usuario Update(Usuario entity)
        {
            if (!entity.Validar())
                return entity;
            if (entity.Valido)
            {
                if (_InstituicaoDeEnsinoRepository.GetById(entity.IdInstituicaoDeEnsino) == null)
                {
                    entity.ListaErros.Add("Instituicao de ensino não encontrada");
                }
                else
                {
                    _UsuarioRepository.Update(entity);
                    _unitOfWork.Commit();
                }
            }

            return entity;
        }

        public bool Delete(Usuario entity)
        {

            _UsuarioRepository.Delete(entity);
            _unitOfWork.Commit();
            if (!_unitOfWork.Sucesso())
                entity.AdicionaErro("Não foi possível excluir, pois o cadastrado já gerou algum outro cadastro depedente");
            return _unitOfWork.Sucesso();
        }

        public Usuario GetById(int UsuarioId)
        {
            return _UsuarioRepository.GetById(UsuarioId);
        }

        public IEnumerable<Usuario> ObertTodos()
        {
            return _UsuarioRepository.GetAll();
        }

        public void Dispose()
        {
            _UsuarioRepository.Dispose();
        }

    }
}
