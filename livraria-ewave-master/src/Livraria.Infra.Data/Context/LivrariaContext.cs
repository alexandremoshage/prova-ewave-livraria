using Livraria.Domain.Entities;
using Livraria.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Context
{
    public class LivrariaContext : DbContext
    {

        public LivrariaContext(DbContextOptions<LivrariaContext> options)
            : base(options)
        { }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<InstituicaoDeEnsino> InstituicaoDeEnsino { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioLivroEmprestado> UsuarioLivroEmprestado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new LivroMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new InstituicaoDeEnsinoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioLivroEmprestadoMapping());


        }
    }
}
