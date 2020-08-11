using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int IdInstituicaoDeEnsino { get; set; }
    }
}
