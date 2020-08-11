using Livraria.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Livraria.Domain.Entities
{
    public class InstituicaoDeEnsino : EntityBase
    {

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
        public bool Validar()
        {
            this.ValidarNome();
            this.ValidarEndereço();
            this.ValidarCPNJ();
            return this.Valido;
        }

        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(this.Nome))
                this.AdicionaErro("Nome da instituição de ensino é obrigatório");

            if (this.Valido && this.Nome.Length > 1000)
                this.AdicionaErro("Nome não pode ter mais do que mil caracters");
        }
        public void ValidarEndereço()
        {
            if (string.IsNullOrEmpty(this.Endereco))
                this.AdicionaErro("Endereço é obrigatório");

            if (this.Valido && this.Endereco.Length > 1000)
                this.AdicionaErro("Endereço não pode ter mais do que mil caracters");
        }

        public void ValidarCPNJ()
        {
            if (string.IsNullOrEmpty(this.CNPJ))
                this.AdicionaErro("CNPJ é obrigatório");

            if (ListaErros.Count == 0)
            {
                if (this.CNPJ.Length != 14)
                    this.AdicionaErro("CNPJ dever ter 14 Dígitos");
            }

            if (ListaErros.Count == 0)
            {
                if (!Regex.IsMatch(CNPJ, "^\\d+$"))
                    this.AdicionaErro("CNPJ dever ter apenas números");
            }

           

            if (ListaErros.Count == 0)
            {
                if (!ValidarDigitoVerificadoCPJ())
                    this.AdicionaErro("CNPJ inválido");
            }
        }

        private bool ValidarDigitoVerificadoCPJ()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            CNPJ = CNPJ.Trim();
            if (CNPJ.Length != 14)
                return false;
            tempCnpj = CNPJ.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return CNPJ.EndsWith(digito);
        }
    }
}
