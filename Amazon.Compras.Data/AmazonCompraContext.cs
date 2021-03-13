using Amazon.Compras.Domain;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Compras.Data
{
    public partial class AmazonCompraContext : DbContext
    {
        public AmazonCompraContext(DbContextOptions<AmazonCompraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<CompraProduto> CompraProduto { get; set; }
        public virtual DbSet<Desejos> Desejos { get; set; }
        public virtual DbSet<ItemDesejo> ItemDesejo { get; set; }
              
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<CompraProduto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompraId).HasColumnName("CompraID");

                entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");

                entity.Property(e => e.ValorProduto).HasColumnType("money");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.CompraProduto)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CompraPro__Compr__4BAC3F29");
            });

            modelBuilder.Entity<Desejos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ItemDesejo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DesejoId).HasColumnName("DesejoID");

                entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");

                entity.HasOne(d => d.Desejo)
                    .WithMany(p => p.ItemDesejo)
                    .HasForeignKey(d => d.DesejoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemDesej__Desej__46E78A0C");
            });
        }
    }
}
