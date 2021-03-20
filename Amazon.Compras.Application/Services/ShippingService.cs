using Amazon.Compras.Application.Queries.ViewModels;
using Amazon.Compras.Domain;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Amazon.Compras.Application.Services
{
    public class ShippingService : IShippingService
    {
        private IPurchaseRepository _purchaseRepository;

        public ShippingService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<ShippingViewModel> CalculateShipping(int purchaseId, string zipCode)
        {
            var shippingViewModel = new ShippingViewModel
            {
                Success = false
            };
            var regexZipCode = new Regex(@"^\d{8})$|^\d{5}-{1}\d{3}$");
            if (!regexZipCode.IsMatch(zipCode))
            {
                shippingViewModel.ErrorMessage = $"Zipcode {zipCode} invalid.";
                return shippingViewModel;
            }
            var isCompraValida = await _purchaseRepository.ExisteCompraComID(purchaseId);
            if (!isCompraValida)
            {
                shippingViewModel.ErrorMessage = $"Purchase ID: {purchaseId} doesn't exist.";
                return shippingViewModel;
            }
            var twoLastChars = Int32.Parse(zipCode.Substring(zipCode.Length - 2));
            shippingViewModel.Success = true;
            shippingViewModel.ShippingValue = purchaseId * twoLastChars;
            return shippingViewModel;

        }
    }
}
