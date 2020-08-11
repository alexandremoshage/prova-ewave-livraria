using Livraria.test.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.test.TestEntidades
{
    [TestClass]
    public class UsuarioTests
    {
        [TestMethod]
        public void CriarLivroValido()
        {
            var usaurio = new UsuarioBuilder().Build();
            usaurio.Validar();
            Assert.AreEqual(true, usaurio.Valido);
        }

        [DataRow(null)]
        [DataRow("")]
        [TestMethod]
        public void DeveCriticarNomeInvalido(string nome)
        {
            var usaurio = new UsuarioBuilder().Build();
            usaurio.Nome = nome;
            usaurio.Validar();
            Assert.AreEqual(false, usaurio.Valido);
        }

        [TestMethod]
        public void DeveCriticarNomeGigante()
        {
            var usaurio = new UsuarioBuilder().Build();
            usaurio.Nome = "".PadLeft(10000, 'A');
            usaurio.Validar();
            Assert.AreEqual(false, usaurio.Valido);
        }



        [DataRow(null)]
        [DataRow("")]
        [TestMethod]
        public void DeveCriticarEnderecoInvalido(string endereco)
        {
            var usaurio = new UsuarioBuilder().Build();
            usaurio.Endereco = endereco;
            usaurio.Validar();
            Assert.AreEqual(false, usaurio.Valido);
        }

        [TestMethod]
        public void DeveCriticarEnderecoGigante()
        {
            var usaurio = new UsuarioBuilder().Build();
            usaurio.Endereco = "".PadLeft(10000, 'A');
            usaurio.Validar();
            Assert.AreEqual(false, usaurio.Valido);
        }


        [DataRow(null)]
        [DataRow("")]
        [DataRow("12345678910")]
        [TestMethod]
        public void DeveCriticarCPFInvalido(string cpf)
        {
            var usaurio = new UsuarioBuilder().Build();
            usaurio.CPF = cpf;
            usaurio.Validar();
            Assert.AreEqual(false, usaurio.Valido);
        }


        [DataRow(null)]
        [DataRow("")]
        [DataRow("123")]
        [TestMethod]
        public void DeveCriticarTelefoneInvalido(string telefone)
        {
            var usaurio = new UsuarioBuilder().Build();
            usaurio.Telefone = telefone;
            usaurio.Validar();
            Assert.AreEqual(false, usaurio.Valido);
        }


    }
}