using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependenciasInfraestrutura
    {
        public static IServiceCollection RegistrarDependenciasInfraestrutura(
            this IServiceCollection services)
        {
            //Entity
            services.AddDbContext<SoftDesignContext>(options =>
               options.UseSqlServer("")
               );

            return services;
        }
    }
}
