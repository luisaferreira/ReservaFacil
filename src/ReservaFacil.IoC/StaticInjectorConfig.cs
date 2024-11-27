using Microsoft.Extensions.DependencyInjection;
using ReservaFacil.Data.Repositories;
using ReservaFacil.Domain.Interfaces.Repositories;

namespace ReservaFacil.IoC
{
    public static class StaticInjectorConfig
    {
        public static void RegisterStaticDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
