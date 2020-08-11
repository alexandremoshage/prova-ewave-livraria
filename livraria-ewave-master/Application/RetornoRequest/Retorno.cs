using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RetornoRequest
{
    public class Retorno
    {
        public Boolean Sucesso { get => ListaErros.Count == 0; }
        public List<string> ListaErros { get; set; }
        public int Id { get; set; }

        public Retorno () {
            ListaErros = new List<string>();   
        }

    }
}
