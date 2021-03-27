using System.Collections.Generic;

namespace Amazon.Purchases.ViewModel
{
    public class PurchaseResponse
    {
        public int PurchaseId { get; set; }
        public List<ProductResponse> Products { get; set; }
        public decimal TotalValue { get; set; }
    }
}
