using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Services
{
    public class UsuarioLivroEmprestadoService : IUsuarioLivroEmprestadoService
    {

        private readonly IUsuarioLivroEmprestadoRepository _UsuarioLivroEmprestadoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioLivroEmprestadoService(IUsuarioLivroEmprestadoRepository UsuarioLivrosEmpretadosRepository, IUnitOfWork unitOfWork)
        {
            _UsuarioLivroEmprestadoRepository = UsuarioLivrosEmpretadosRepository;
            _unitOfWork = unitOfWork;
        }

        public UsuarioLivroEmprestado Save(UsuarioLivroEmprestado entity)
        {
            if (!entity.Validar())
                return entity;

            if (entity.Valido)
            {
                _UsuarioLivroEmprestadoRepository.Save(entity);
                _unitOfWork.Commit();
            }
            return entity;
        }

        public UsuarioLivroEmprestado Update(UsuarioLivroEmprestado entity)
        {
            if (!entity.Validar())
                return entity;
            if (entity.Valido)
            {
                _UsuarioLivroEmprestadoRepository.Update(entity);
                _unitOfWork.Commit();
            }

            return entity;
        }

        public bool Delete(UsuarioLivroEmprestado entity)
        {

            _UsuarioLivroEmprestadoRepository.Delete(entity);
            if (!_unitOfWork.Sucesso())
                entity.AdicionaErro("Não foi possível excluir, pois o cadastrado já gerou algum outro cadastro depedente");
            _unitOfWork.Commit();

            return _unitOfWork.Sucesso();
        }


        public void Dispose()
        {
            _UsuarioLivroEmprestadoRepository.Dispose();
        }

      
    }
}
