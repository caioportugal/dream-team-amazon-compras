using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Compras.Domain
{
    public interface ICompraRepository
    {
        Task<Compra> ObterDadosCompra(int idCompra);
        Task<bool> ExisteCompraComID(int id);
    }
}
