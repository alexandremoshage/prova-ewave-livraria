using Livraria.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entities
{
    public class Livro : EntityBase
    {

        public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime Publicacao { get; set; }
        public int Paginas { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Descricao { get; set; }
        public bool Emprestado { get; set; }
        public bool Reservado { get; set; }
        public virtual Usuario UsuarioReserva { get; set; }
        public int? IdUsuarioReserva { get; set; }
        public bool Validar()
        {
            this.ValidarTituloLivro();
            this.ValidarGeneroLivro();
            this.ValidarAutor();
            this.ValidarEditora();
            this.ValidarPaginas();
            this.ValidarDescricao();
            return this.Valido;
        }

        private void ValidarTituloLivro()
        {
            if (string.IsNullOrEmpty(this.Titulo))
                this.AdicionaErro("Título do Livro é obrigatório");

            if (this.Valido && this.Titulo.Length > 1000)
                this.AdicionaErro("Título não pode ter mais do que mil caracters");
        }
        public void ValidarAutor()
        {
            if (string.IsNullOrEmpty(this.Autor))
                this.AdicionaErro("Autor do Livro é obrigatório");

            if (this.Valido && this.Autor.Length > 1000)
                this.AdicionaErro("Autor não pode ter mais do que mil caracters");
        }
        public void ValidarDescricao()
        {
            if (string.IsNullOrEmpty(this.Descricao))
                this.AdicionaErro("Descrição do livro não pode ser vázio");

            if (this.Valido && this.Descricao.Length <= 5)
                this.AdicionaErro("Descrição do livro deve ser maior do que 5 caracters");
        }
        public void ValidarEditora()
        {
            if (string.IsNullOrEmpty(this.Editora))
                this.AdicionaErro("Editora do Livro é obrigatório");

            if (this.Valido && this.Editora.Length > 100)
                this.AdicionaErro("Editora do Livro não pode ter mais do que 100 caracteres");
        }
        public void ValidarPaginas()
        {
            if (this.Paginas <= 0)
                this.AdicionaErro("Quantidade de páginas é obrigatório");

            if (this.Paginas >= 300000)
                this.AdicionaErro("Quantidade de Páginas não pode ser maior do que 300 mil ");
        }
        private void ValidarGeneroLivro()
        {
            if (string.IsNullOrEmpty(this.Genero))
                this.AdicionaErro("Genero do Livro é obrigatório");

            if (this.Valido && this.Genero.Length > 1000)
                this.AdicionaErro("Gênero do Livro não é pode ser maior do que mil caracters");
        }

        public bool DevolverLivro()
        {
            if (Emprestado)
            {
                Reservado = false;
                IdUsuarioReserva = null;
                Emprestado = false;
                return true;
            }
            else
            {
                this.AdicionaErro("O livro não está emprestado.");
                return false;
            }
        }

        public bool EmprestarLivro(Usuario usuarioEmprestar)
        {
            if (Emprestado)
            {
                this.AdicionaErro("O livro já está emprestado");
                return false;
            }

            if (Reservado && UsuarioReserva?.Id != usuarioEmprestar.Id)
            {
                this.AdicionaErro("O livro já está reservado para o usuáro " + UsuarioReserva.Nome);
                return false;
            }
            Reservado = false;
            IdUsuarioReserva = null;
            Emprestado = true;
            return true;
        }


        public bool Reservar(Usuario usuarioReservar)
        {
            if (Emprestado)
            {
                this.AdicionaErro("O livro já está emprestado");
                return false;
            }

            if (Reservado)
            {
                this.AdicionaErro("O livro já está reservado para o usuáro " + UsuarioReserva.Nome);
                return false;
            }
            IdUsuarioReserva = usuarioReservar.Id;
            Reservado = true;
            return true;
        }
    }
}