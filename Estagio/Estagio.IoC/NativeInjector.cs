using Estagio.Application.Interfaces;
using Estagio.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Template.Data.Repositories;
using Template.Domain.Interfaces;

namespace Estagio.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            
            services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion
        }
    }
}
