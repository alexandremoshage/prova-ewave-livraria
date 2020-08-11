using Livraria.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Livraria.Domain.Entities
{
    public class Usuario : EntityBase
    {

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public int IdInstituicaoDeEnsino { get; set; }
        public virtual InstituicaoDeEnsino InstituicaoDeEnsino { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<UsuarioLivroEmprestado> LivrosEmprestados { get; set; } = new HashSet<UsuarioLivroEmprestado>();

        public bool Validar()
        {
            this.ValidarNome();
            this.ValidarEndereço();
            this.ValidarCPF();
            this.ValidarTelefone();
            return this.Valido;
        }

        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(this.Nome))
                this.AdicionaErro("Nome da instituição de ensino é obrigatório");

            if (this.Valido && this.Nome.Length > 1000)
                this.AdicionaErro("Nome não pode ter mais do que mil caracters");
        }

        public void ValidarApitoEmprestarLivro()
        {
            if (this.LivrosEmprestados.Where(x => x.Devolvido == false).Count() >= 2)
                this.AdicionaErro("O Usuário não pode emprestar mais de dois livros");
        }
        private void ValidarEndereço()
        {
            if (string.IsNullOrEmpty(this.Endereco))
                this.AdicionaErro("Endereço é obrigatório");

            if (this.Valido && this.Endereco.Length > 1000)
                this.AdicionaErro("Endereço não pode ter mais do que mil caracters");
        }
        private void ValidarCPF()
        {
            if (string.IsNullOrEmpty(this.CPF))
                this.AdicionaErro("CPF é obrigatório");

            if (this.CPF?.Length != 11)
                this.AdicionaErro("CPF dever ter 11 Dígitos");

            if (ListaErros.Count == 0)
            {
                if (!Regex.IsMatch(CPF, "^\\d+$"))
                    this.AdicionaErro("CPF dever ter apenas números");
            }

            if (ListaErros.Count == 0)
            {
                if (!ValidarDigitoVerificadoCpf())
                    this.AdicionaErro("CPF inválido");
            }
        }

        private void ValidarTelefone()
        {
            if (string.IsNullOrEmpty(this.Telefone))
                this.AdicionaErro("Telefone é obrigatório");

            if (this.Telefone?.Length < 9)
                this.AdicionaErro("Telefone dever ter mais de 9 digitos");
        }


        private bool ValidarDigitoVerificadoCpf()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            CPF = CPF.Trim();
            if (CPF.Length != 11)
                return false;
            tempCpf = CPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return CPF.EndsWith(digito);
        }
    }
}
