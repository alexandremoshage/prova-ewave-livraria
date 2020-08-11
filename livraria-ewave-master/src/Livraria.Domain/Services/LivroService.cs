using Livraria.Domain.Entities;
using Livraria.Domain.Entities.Base;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.Domain.Services
{
    public class LivroService : ILivroService
    {

        private readonly ILivroRepository _livroRepository;
        private readonly IUsuarioLivroEmprestadoRepository _usuarioLivroEmprestadoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LivroService(ILivroRepository livroRepository, 
                            IUsuarioLivroEmprestadoRepository usuarioLivroEmprestadoRepository,
                            IUnitOfWork unitOfWork)
        {
            _livroRepository = livroRepository;
            _usuarioLivroEmprestadoRepository = usuarioLivroEmprestadoRepository;
            _unitOfWork = unitOfWork;
        }

        public Livro Save(Livro entity)
        {
            if (!entity.Validar())
                return entity;

            if (entity.Valido)
            {
                _livroRepository.Save(entity);
                _unitOfWork.Commit();
            }
            return entity;
        }

        public Livro Update(Livro entity)
        {
            if (!entity.Validar())
                return entity;
            if (entity.Valido)
            {
                _livroRepository.Update(entity);
                _unitOfWork.Commit();
            }

            return entity;
        }

        public EntityBase Emprestar(Livro livro, Usuario usuario)
        {
            var UsuarioLivroEmprestado = new UsuarioLivroEmprestado();
           

            usuario.ValidarApitoEmprestarLivro();
            if (!livro.EmprestarLivro(usuario))
                return livro;
            if (!usuario.Valido)
                return usuario;
            if (livro.Valido)
            {
                UsuarioLivroEmprestado.IdLivro = livro.Id;
                UsuarioLivroEmprestado.IdUsuario = usuario.Id;
                UsuarioLivroEmprestado.DataEmprestimo = DateTime.Now;
                _livroRepository.Update(livro);
               _usuarioLivroEmprestadoRepository.Save(UsuarioLivroEmprestado);
                _unitOfWork.Commit();
            }
            return UsuarioLivroEmprestado;
        }

        public EntityBase Devolver(Livro livro, Usuario usuario)
        {
            var UsuarioLivroEmprestado = usuario.LivrosEmprestados.Where(x => x.IdLivro == livro.Id && x.Devolvido == false).FirstOrDefault();
            if (!livro.DevolverLivro())
                return livro;
            if (UsuarioLivroEmprestado == null)
            {
                livro.AdicionaErro("Emprestimo não encontrado");
                return livro;
            }
            if (livro.Valido)
            {
                UsuarioLivroEmprestado.Devolvido = true;
                UsuarioLivroEmprestado.DataDevolucao = DateTime.Now;
                _livroRepository.Update(livro);
                _usuarioLivroEmprestadoRepository.Update(UsuarioLivroEmprestado);
                _unitOfWork.Commit();
            }
            return UsuarioLivroEmprestado;
        }

        public EntityBase Reservar(Livro livro, Usuario usuario)
        {
            if (!livro.Reservar(usuario))
                return livro;

            if (!usuario.Valido)
                return usuario;
            if (livro.Valido)
            {
                _livroRepository.Update(livro);
                _unitOfWork.Commit();
            }
            return livro;
        }


        public bool Delete(Livro entity)
        {
            
            _livroRepository.Delete(entity);
            _unitOfWork.Commit();
            if (!_unitOfWork.Sucesso())
                entity.AdicionaErro("Não foi possível excluir, pois o cadastrado já gerou algum outro cadastro depedente");
            return _unitOfWork.Sucesso();
        }

        public Livro GetById(int Id)
        {
            return _livroRepository.GetById(Id);
        }

        public IEnumerable<Livro> ObertTodos()
        {
            return _livroRepository.GetAll();
        }

        public IEnumerable<Livro> ObertParaEmprestar()
        {
            return _livroRepository.GetParaEmprestar();
        }

        public IEnumerable<Livro> ObertParaDevolver(int idUsuario)
        {
            return _livroRepository.GetParaDevolver(idUsuario);
        }

        public IEnumerable<Livro> FiltrarTitulo(string filtro)
        {
            return _livroRepository.GetByFilter(filtro);
        }


        public void Dispose()
        {
            _livroRepository.Dispose();
        }

    }
}
