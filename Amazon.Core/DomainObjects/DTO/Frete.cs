using System;

namespace Amazon.Core.DomainObjects.DTO
{
    public class Frete
    {
        public Guid PedidoId { get; set; }
        public string Cep { get; set; }
    }
}
