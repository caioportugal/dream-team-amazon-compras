using Amazon.Purchases.Model;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Purchases.Database
{
    public class PurchaseContext : DbContext
    {
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseProduct> PurchaseProduct { get; set; }
        public virtual DbSet<Wish> Wish { get; set; }
        public virtual DbSet<WishItem> WishItem { get; set; }
    }
}