using System;
using System.Collections.Generic;

namespace Amazon.Compras.Domain
{
    public partial class ItemDesejo
    {
        public int Id { get; set; }
        public int DesejoId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Desejos Desejo { get; set; }
    }
}
