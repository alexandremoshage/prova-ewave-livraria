using Livraria.Domain.Entities;
using Livraria.test.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.test.TestEntidades
{
    [TestClass]
    public class LivroTests
    {
        [TestMethod]
        public void CriarLivroValido()
        {
            var livro =  new LivroBuilder().Build();
            livro.Validar();
            Assert.AreEqual(true, livro.Valido);
        }


        [TestMethod]
        public void DeveCriticaFaltaDeTituloInvalido()
        {
            var livro = new LivroBuilder().Build();
            livro.Titulo = null;
            livro.Validar();
            Assert.AreEqual(false, livro.Valido);
        }

        [TestMethod]
        public void DeveCriticarGeneroNaoInformado()
        {
            var livro = new LivroBuilder().Build();
            livro.Genero = null;
            livro.Validar();
            Assert.AreEqual(false, livro.Valido);
        }

        [TestMethod]
        public void DeveCriticarGeneroInformadoMaiorQueOPermitido()
        {
            var livro = new LivroBuilder().Build();
            livro.Genero = "".PadLeft(100000,'A');
            livro.Validar();
            Assert.AreEqual(false, livro.Valido);
        }


        [TestMethod]
        public void DeveCriticarEditoraNaoInformado()
        {
            var livro = new LivroBuilder().Build();
            livro.Editora = null;
            livro.Validar();
            Assert.AreEqual(false, livro.Valido);
        }

        [TestMethod]
        public void DeveCriticarEditoraInformadoMaiorQueOPermitido()
        {
            var livro = new LivroBuilder().Build();
            livro.Editora = "".PadLeft(100000, 'A');
            livro.Validar();
            Assert.AreEqual(false, livro.Valido);
        }


        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(3000000)]
        public void DeveCriticarPaginasInvalidas(int paginas)
        {
            var livro = new LivroBuilder().Build();
            livro.Paginas = paginas;
            livro.Validar();
            Assert.AreEqual(false, livro.Valido);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("1234")]
        public void DeveCriticarDescricaoInvalida(string descricao)
        {
            var livro = new LivroBuilder().Build();
            livro.Descricao = descricao;
            livro.Validar();
            Assert.AreEqual(false, livro.Valido);
        }

        [TestMethod]
        public void DeveNaoDevolverLivroEmprestado()
        {
            var livro = new LivroBuilder().Build();
            livro.Emprestado = false;
            var resultado =  livro.DevolverLivro();
            Assert.AreEqual(false, resultado);
        }

        [TestMethod]
        public void DeveDevolverLivroEmprestado()
        {
            var livro = new LivroBuilder().Build();
            livro.Emprestado = true;
            var resultado = livro.DevolverLivro();
            Assert.AreEqual(true, resultado);
        }


        [TestMethod]
        public void DeveNaoEmprestarLivroEmprestado()
        {
            var livro = new LivroBuilder().Build();
            livro.Emprestado = true;
            var resultado = livro.EmprestarLivro( new UsuarioBuilder().Build());
            Assert.AreEqual(false, resultado);
        }

        [TestMethod]
        public void DeveNaoEmprestarLivroReservado()
        {
            var livro = new LivroBuilder().Build();
            livro.UsuarioReserva = new UsuarioBuilder().BuildOutroUsuario();
            livro.Reservado = true;
            var resultado = livro.EmprestarLivro(new UsuarioBuilder().Build());
            Assert.AreEqual(false, resultado);
        }

        [TestMethod]
        public void DeveEmprestarLivroReservadoParaOUsuarioDaReserva()
        {
            var livro = new LivroBuilder().Build();
            livro.UsuarioReserva = new UsuarioBuilder().Build();
            livro.Reservado = true;
            var resultado = livro.EmprestarLivro(new UsuarioBuilder().Build());
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void DeveEmprestarLivroNaoEmprestado()
        {
            var livro = new LivroBuilder().Build();
            livro.Emprestado = false;
            var resultado = livro.EmprestarLivro(new UsuarioBuilder().Build());
            Assert.AreEqual(true, resultado);
        }
    }
}
