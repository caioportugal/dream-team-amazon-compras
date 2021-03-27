using Amazon.Purchases.Resources.Response;
using Amazon.Purchases.ViewModel;
namespace Amazon.Purchases.Services
{
    public interface IWishService
    {
        WishResponse AddWish(WishRequest wishesViewModel);
        WishResponse GetWish(int id);
    }
}
