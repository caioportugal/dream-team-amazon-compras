using Amazon.Compras.Application.Queries.ViewModels;
using System.Threading.Tasks;

namespace Amazon.Compras.Application.Services
{
    public interface IFreteService
    {
        Task<FreteViewModel> CalcularFreteAsync(int idCompra, string cep);
    }
}
