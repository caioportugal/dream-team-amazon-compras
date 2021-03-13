using Amazon.Compras.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Compras.Data.Repository
{
    public class DesejoRepository : IDesejoRepository
    {
        private readonly AmazonCompraContext _context;
        public DesejoRepository(AmazonCompraContext context)
        {
            _context = context;
        }
        public void Adicionar(Desejos desejos)
        {
            _context.Desejos.Add(desejos);
            Commit();
        }

        private void Commit()
        {
            _context.SaveChanges();
        }
    }
}
