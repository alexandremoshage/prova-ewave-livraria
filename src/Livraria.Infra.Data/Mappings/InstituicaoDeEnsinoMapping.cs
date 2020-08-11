using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Mappings
{
   public class InstituicaoDeEnsinoMapping : IEntityTypeConfiguration<InstituicaoDeEnsino>
    {
        public void Configure(EntityTypeBuilder<InstituicaoDeEnsino> builder)
        {

            builder.ToTable("InstituicaodeEnsino");
            builder.HasKey(c => c.Id);
            builder.Property(b => b.Nome);
            builder.Property(b => b.Endereco);
            builder.Property(b => b.CNPJ);
            builder.Ignore(b => b.ListaErros);
            builder.Ignore(b => b.Valido);
        }
    }
}
