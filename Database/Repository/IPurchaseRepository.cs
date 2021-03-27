using Amazon.Purchases.Model;

namespace Amazon.Purchases.Database.Repository
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        bool IsPurchaseExist(int purchase);
        Purchase GetPurchase(int purchase);
    }
}