using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Compras.Domain
{
    public interface IPurchaseRepository
    {
        Task<Compra> GetPurchaseData(int purchaseId);
        Task<bool> ExisteCompraComID(int id);
    }
}
