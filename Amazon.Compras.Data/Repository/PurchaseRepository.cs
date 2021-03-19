using Amazon.Compras.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Amazon.Compras.Data.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AmazonCompraContext _context;

        public PurchaseRepository(AmazonCompraContext context)
        {
            _context = context;
        }
        public async Task<Compra> GetPurchaseData(int id)
        {
            return await _context.Compra.Include(c => c.CompraProduto).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExisteCompraComID(int id)
        {
            return await _context.Compra.AnyAsync(x => x.Id == id);
        }
    }
}
