using Amazon.Purchases.Model;
namespace Amazon.Purchases.Database.Repository
{
    public interface IWishRepository : IRepository<Wish>
    {
        public Wish GetWish(int id);
    }
}