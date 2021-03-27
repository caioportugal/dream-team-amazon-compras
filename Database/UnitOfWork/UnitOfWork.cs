using Amazon.Purchases.Database.Repository;
namespace Amazon.Purchases.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private PurchaseContext _context;
        public UnitOfWork(PurchaseContext context)
        {
            _context = context;
            PurchaseRepository = new PurchaseRepository(_context);
            WishRepository = new WishRepository(_context);
        }
        public IPurchaseRepository PurchaseRepository { get; private set; }
        public IWishRepository WishRepository { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}