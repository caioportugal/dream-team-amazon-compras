using System;
using System.Collections.Generic;

namespace Amazon.Compras.Domain
{
    public partial class Compra
    {
        public Compra()
        {
            CompraProduto = new HashSet<CompraProduto>();
        }

        public int Id { get; set; }

        public virtual ICollection<CompraProduto> CompraProduto { get; set; }
    }
}
