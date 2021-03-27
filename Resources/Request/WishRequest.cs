using System.Collections.Generic;
namespace Amazon.Purchases.ViewModel
{
    public class WishRequest
    {
        public List<WishItemsRequest> WishItems { get; set; }
    }
}