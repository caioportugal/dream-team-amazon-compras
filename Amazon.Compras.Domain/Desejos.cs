using System;
using System.Collections.Generic;

namespace Amazon.Compras.Domain
{
    public partial class Desejos
    {
        public Desejos()
        {
            ItemDesejo = new HashSet<ItemDesejo>();
        }

        public int Id { get; set; }

        public virtual ICollection<ItemDesejo> ItemDesejo { get; set; }
    }
}
