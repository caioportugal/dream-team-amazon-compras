using Amazon.Compras.Application.Services;
using Amazon.Compras.Data;
using Amazon.Compras.Data.Repository;
using Amazon.Compras.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            // Compras
            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<IDesejoRepository, DesejoRepository>();

            services.AddScoped<ICompraService, CompraServices>();
            services.AddScoped<AmazonCompraContext>();

            
        }
    }
}
