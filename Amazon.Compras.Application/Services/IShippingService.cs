using Amazon.Compras.Application.Queries.ViewModels;
using System.Threading.Tasks;

namespace Amazon.Compras.Application.Services
{
    public interface IShippingService
    {
        Task<ShippingViewModel> CalculateShipping(int purchaseId, string zipCode);
    }
}
