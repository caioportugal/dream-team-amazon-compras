using Amazon.Compras.Application.Queries.ViewModels;
using System.Threading.Tasks;

namespace Amazon.Compras.Application.Services
{
   public interface ICompraService
    {
        Task<DadosCompraViewModel> ObterDadosCompra(int idCompra);
    }
}
