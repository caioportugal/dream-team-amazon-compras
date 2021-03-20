using Amazon.Compras.Application.Queries.ViewModels;
using System.Threading.Tasks;

namespace Amazon.Purchases.Application.Services
{
    public interface IWishService
    {
        Task<bool> AddWish(WishesViewModel wishesViewModel);
    }
}
