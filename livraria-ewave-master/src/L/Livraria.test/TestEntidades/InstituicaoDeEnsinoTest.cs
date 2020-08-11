using Livraria.test.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.test.TestEntidades
{
    [TestClass]
    public class InstituicaoDeEnsinoTest
    {
        [TestMethod]
        public void CriarinstituicaoDeEnsinoValida()
        {
            var instituicaoDeEnsino = new InstituicaoDeEnsinoBuilder().Build();
            instituicaoDeEnsino.Validar();
            Assert.AreEqual(true, instituicaoDeEnsino.Valido);
        }


        [DataRow(null)]
        [DataRow("")]
        [TestMethod]
        public void DeveCriticarNomeInvalido(string nome)
        {
            var instituicaoDeEnsino = new InstituicaoDeEnsinoBuilder().Build();
            instituicaoDeEnsino.Nome = nome;
            instituicaoDeEnsino.Validar();
            Assert.AreEqual(false, instituicaoDeEnsino.Valido);
        }

        [TestMethod]
        public void DeveCriticarNomeGigante()
        {
            var instituicaoDeEnsino = new InstituicaoDeEnsinoBuilder().Build();
            instituicaoDeEnsino.Nome = "".PadLeft(10000, 'A');
            instituicaoDeEnsino.Validar();
            Assert.AreEqual(false, instituicaoDeEnsino.Valido);
        }


        [DataRow(null)]
        [DataRow("")]
        [TestMethod]
        public void DeveCriticarEnderecoInvalido(string endereco)
        {
            var instituicaoDeEnsino= new InstituicaoDeEnsinoBuilder().Build();
            instituicaoDeEnsino.Endereco = endereco;
            instituicaoDeEnsino.Validar();
            Assert.AreEqual(false, instituicaoDeEnsino.Valido);
        }

        [TestMethod]
        public void DeveCriticarEnderecoGigante()
        {
            var instituicaoDeEnsino = new InstituicaoDeEnsinoBuilder().Build();
            instituicaoDeEnsino.Endereco = "".PadLeft(10000, 'A');
            instituicaoDeEnsino.Validar();
            Assert.AreEqual(false, instituicaoDeEnsino.Valido);
        }


        [DataRow(null)]
        [DataRow("")]
        [DataRow("12345678910")]
        [TestMethod]
        public void DeveCriticarCNPJInvalido(string cnpj)
        {
            var instituicaoDeEnsino = new InstituicaoDeEnsinoBuilder().Build();
            instituicaoDeEnsino.CNPJ = cnpj;
            instituicaoDeEnsino.Validar();
            Assert.AreEqual(false, instituicaoDeEnsino.Valido);
        }

    }
}
