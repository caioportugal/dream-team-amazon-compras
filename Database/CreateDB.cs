using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.Purchases.Database
{
    public static class CreateDB
    {
        public static void ExecuteMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PurchaseContext>();
                context.Database.Migrate();
            }
        }
    }
}