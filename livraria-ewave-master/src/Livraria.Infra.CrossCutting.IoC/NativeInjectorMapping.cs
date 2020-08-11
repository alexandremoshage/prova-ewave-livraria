using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.Services;
using Livraria.Domain.UnitOfWork;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.Repositories;
using Livraria.Infra.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.CrossCutting.IoC
{
    public class NativeInjectorMapping
    {
        public static void RegisterServices(IServiceCollection services)
        { 
            RegisterServicesDomain(services);
            RegisterServicesRepository(services);
            services.AddScoped<LivrariaContext>();
        }
          
        private static void RegisterServicesDomain(IServiceCollection services)
        {
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IInstituicaoDeEnsinoService, InstituicaoDeEnsinoService>();
            services.AddScoped<IUsuarioLivroEmprestadoService, UsuarioLivroEmprestadoService>();
        }

        private static void RegisterServicesRepository(IServiceCollection services)
        {
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IInstituicaoDeEnsinoRepository, InstituicaoDeEnsinoRepository>();
            services.AddScoped<IUsuarioLivroEmprestadoRepository, UsuarioLivroEmprestadoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
