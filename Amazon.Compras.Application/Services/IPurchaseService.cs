using Amazon.Compras.Application.Queries.ViewModels;
using System.Threading.Tasks;

namespace Amazon.Compras.Application.Services
{
   public interface IPurchaseService
    {
        Task<PurchaseDataViewModel> GetPurchaseData(int purchaseId);
    }
}
