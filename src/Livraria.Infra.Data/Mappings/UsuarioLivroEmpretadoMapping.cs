using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Mappings
{
    public class UsuarioLivroEmprestadoMapping : IEntityTypeConfiguration<UsuarioLivroEmprestado>
    {
        public void Configure(EntityTypeBuilder<UsuarioLivroEmprestado> builder)
        {

            builder.ToTable("UsuarioLivroEmprestado");
            builder.HasKey(c => c.Id);
            builder.Property(b => b.IdLivro);
            builder.Property(b => b.IdUsuario);
            builder.Property(b => b.DataEmprestimo);
            builder.Property(b => b.DataDevolucao);
            builder.Property(b => b.Devolvido);

            builder.Ignore(b => b.ListaErros);
            builder.Ignore(b => b.Valido);



        }
    }
}
