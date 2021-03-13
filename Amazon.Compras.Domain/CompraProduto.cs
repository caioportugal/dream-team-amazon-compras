using System;
using System.Collections.Generic;

namespace Amazon.Compras.Domain
{
    public partial class CompraProduto
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public decimal ValorProduto { get; set; }

        public virtual Compra Compra { get; set; }
    }
}
