using System.Collections.Generic;

namespace Amazon.Compras.Application.Queries.ViewModels
{
    public class DadosCompraViewModel
    {
        public List<CompraProdutoViewModel> ItensCompra { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
