using Amazon.Compras.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Amazon.Compras.Data.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly AmazonCompraContext _context;

        public CompraRepository(AmazonCompraContext context)
        {
            _context = context;
        }
        public async Task<Compra> ObterDadosCompra(int id)
        {
            return await _context.Compra.Include(c => c.CompraProduto).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
