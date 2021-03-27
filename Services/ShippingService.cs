using Amazon.Purchases.Database;
using Amazon.Purchases.Database.UnitOfWork;
using Amazon.Purchases.ViewModel;
using System.Text.RegularExpressions;

namespace Amazon.Purchases.Services
{
    public class ShippingService : IShippingService
    {
        private PurchaseContext _context;

        public ShippingService(PurchaseContext context)
        {
            _context = context;
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

            if (!IsValidPurchase(purchaseId))
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
        private bool IsValidPurchase(int purchaseId)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                return unitOfWork.PurchaseRepository.IsPurchaseExist(purchaseId);
            }
        }
    }
}
