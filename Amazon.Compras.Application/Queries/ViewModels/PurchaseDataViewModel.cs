using System.Collections.Generic;

namespace Amazon.Compras.Application.Queries.ViewModels
{
    public class PurchaseDataViewModel
    {
        public List<ProductPurchaseViewModel> PurchaseItems { get; set; }
        public decimal TotalValue { get; set; }
    }
}
