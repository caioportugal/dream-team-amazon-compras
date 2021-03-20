using Amazon.Compras.Domain;

namespace Amazon.Compras.Data.Repository
{
    public class WishRepository : IWishRepository
    {
        private readonly AmazonCompraContext _context;
        public WishRepository(AmazonCompraContext context)
        {
            _context = context;
        }
        public void Add(Desejos desejos)
        {
            _context.Desejos.Add(desejos);
            Commit();
        }

        private void Commit()
        {
            _context.SaveChanges();
        }
    }
}
