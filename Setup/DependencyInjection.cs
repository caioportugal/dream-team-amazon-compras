using Amazon.Purchases.Database;
using Amazon.Purchases.Integration;
using Amazon.Purchases.Services;
using Amazon.Purchases.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.Suporte.Setup.Services
{
    public static class DependencyInjection
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IPurchaseService, PurchaseService>();
			services.AddScoped<IShippingService, ShippingService>();
			services.AddScoped<IWishService, WishService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductIntegration, ProductIntegration>();
			services.AddScoped<DbContext, PurchaseContext>();
			services.AddScoped<PurchaseContext>();
		}
	}
}