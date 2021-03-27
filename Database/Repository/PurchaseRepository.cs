using Amazon.Purchases.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Amazon.Purchases.Database.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(PurchaseContext context) : base(context) { }
        private PurchaseContext PurchaseContext
        {
            get { return Context; }
        }

        public Purchase GetPurchase(int purchase)
        {
            return PurchaseContext
                   .Purchase.Include(x => x.PurchaseProduct)
                   .FirstOrDefault(x=>x.Id == purchase);
        }

        public bool IsPurchaseExist(int id)
        {
            return PurchaseContext.Purchase.Any(x => x.Id == id);
        }
    }
}