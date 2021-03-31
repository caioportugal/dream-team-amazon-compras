using Amazon.Purchases.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Amazon.Purchases.Database.Repository
{
    public class WishRepository : Repository<Wish>, IWishRepository
    {
        public WishRepository(PurchaseContext context) : base(context) { }
        private PurchaseContext PurchaseContext
        {
            get { return Context; }
        }
        public Wish GetWish(int id)
        {
            return PurchaseContext.Wish
                    .Include(x => x.WishItem)
                    .FirstOrDefault(x=>x.Id == id);
        }
    }
}
