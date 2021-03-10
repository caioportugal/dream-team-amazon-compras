using System;
using System.Collections.Generic;

namespace Amazon.Core.DomainObjects.DTO
{
    public class ListaDesejo
    {
        public Guid UsuarioId { get; set; }
        public ICollection<Item> Itens { get; set; }
    }
}
