using Amazon.Purchases.ViewModel;

namespace Amazon.Purchases.Services
{
    public interface IShippingService
    {
        ShippingResponse CalculateShipping(int purchaseId, string zipCode);
    }
}