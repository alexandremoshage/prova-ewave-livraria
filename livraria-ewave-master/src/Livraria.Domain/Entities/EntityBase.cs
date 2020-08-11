using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Livraria.Domain.Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public EntityBase()
        {
            this.ListaErros = new List<string>();
        }
        [NotMapped]
        public List<string> ListaErros { get; set; }

        [NotMapped]
        public bool Valido { get => this.ListaErros.Count == 0; }
        public void AdicionaErro(string erro) => this.ListaErros.Add(erro);
    }
}
