using Amazon.Compras.Application.Services;
using Amazon.Compras.Data;
using Amazon.Compras.Data.Repository;
using Amazon.Compras.Domain;
using Amazon.Purchases.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Compras
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IWishRepository, WishRepository>();

            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IShippingService, ShippingService>();
            services.AddScoped<IWishService, WishService>();

            services.AddScoped<AmazonCompraContext>();            
        }
    }
}
