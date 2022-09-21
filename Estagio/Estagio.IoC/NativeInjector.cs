using Estagio.Application.Interfaces;
using Estagio.Application.Services;
using Estagio.Data.Repositories;
using Estagio.Domain.Interfaces;
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
            services.AddScoped<ICompraService, CompraService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            #endregion
        }
    }
}
