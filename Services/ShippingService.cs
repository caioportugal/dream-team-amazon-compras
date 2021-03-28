using Amazon.Purchases.ViewModel;
using System.Text.RegularExpressions;

namespace Amazon.Purchases.Services
{
    public class ShippingService : IShippingService
    {
        private IPurchaseService _purchaseService;
        public ShippingService(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        public ShippingResponse CalculateShipping(int purchaseId, string zipCode)
        {
            var shipping = new ShippingResponse
            {
                Success = false,
                ErrorMessage = string.Empty
            };
            if (!isValidZipCode(zipCode))
            {
                shipping.ErrorMessage = $"Zipcode {zipCode} invalid";
                return shipping;
            }
            if (!_purchaseService.IsValidPurchase(purchaseId))
            {
                shipping.ErrorMessage = $"Purchase {purchaseId} doesn't exist.";
                return shipping;
            }
            shipping.Success = true;
            shipping.ShippingValue = purchaseId * int.Parse(zipCode.Substring(zipCode.Length - 2));
            return shipping;
        }

        private bool isValidZipCode(string zipCode)
        {
            var regexZipCode = new Regex(@"^\d{8}$|^\d{5}-{1}\d{3}$");
            return regexZipCode.IsMatch(zipCode);
        }
        
    }
}
