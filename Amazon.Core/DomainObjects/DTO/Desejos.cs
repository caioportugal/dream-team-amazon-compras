using System;
using System.Collections.Generic;

namespace Amazon.Core.DomainObjects.DTO
{
    public class Desejos
    {
        public Guid Id { get; set; }
        public ICollection<Item> ItensDesejo { get; set; }
    }
}
