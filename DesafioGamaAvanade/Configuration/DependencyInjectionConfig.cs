using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Services;
using DesafioGamaAvanade.Data.Interfaces;
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
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IProdutorRepository, ProdutorRepository>();

            services.AddScoped<IArtistaService, ArtistaService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<IProdutorService, ProdutorService>();

            //services.AddScoped<INotificador, Notificador>();
            return services;
        }
    }
}
