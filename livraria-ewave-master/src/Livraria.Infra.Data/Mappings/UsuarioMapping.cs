using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Mappings
{
  public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("Usuario");
            builder.HasKey(c => c.Id);
            builder.Property(b => b.Nome);
            builder.Property(b => b.Endereco);
            builder.Property(b => b.CPF);
            builder.Property(b => b.Telefone);
            builder.Property(b => b.Email);
            builder.Property(b => b.IdInstituicaoDeEnsino);
            builder.Ignore(b => b.ListaErros);
            builder.Ignore(b => b.Valido);

            builder.HasOne(x => x.InstituicaoDeEnsino)
               .WithMany()
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.IdInstituicaoDeEnsino);

            builder
            .HasMany(p => p.LivrosEmprestados)
            .WithOne()
            .HasPrincipalKey(p => p.Id)
            .HasForeignKey(p => p.IdUsuario);

        }
    }
}
