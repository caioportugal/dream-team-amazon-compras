using Amazon.Purchases.ViewModel;
using System.Collections.Generic;

namespace Amazon.Purchases.Resources.Response
{
    public class WishResponse
    {
        public int Id { get; set; }
        public List<ProductResponse> Product { get; set; }
    }
}
