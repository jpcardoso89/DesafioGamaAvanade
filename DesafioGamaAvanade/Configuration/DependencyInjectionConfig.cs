using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Services;
using DesafioGamaAvanade.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IProdutorRepository, ProdutorRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProducaoRepository, ProducaoRepository>();

            services.AddScoped<IArtistaService, ArtistaService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<IProdutorService, ProdutorService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IProducaoService, ProducaoService>();


            //services.AddScoped<INotificador, Notificador>();
            return services;
        }
    }
}
