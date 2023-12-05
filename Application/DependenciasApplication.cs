using Application.Services;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependenciasApplication
    {
        public static IServiceCollection RegisterApplicationDependencies(
            this IServiceCollection services)
        {
            //Services            
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<ILivroService, LivroService>();

            //Repositorios
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();

            return services;
        }
    }
}
