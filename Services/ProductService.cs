using Amazon.Purchases.ErrorHandle;
using Amazon.Purchases.Integration;
using Amazon.Purchases.Services.Interface;
using Amazon.Purchases.ViewModel;

namespace Amazon.Purchases.Services
{
    public class ProductService : IProductService
    {
        private IProductIntegration _productIntegration;
        public ProductService(IProductIntegration productIntegration)
        {
            _productIntegration = productIntegration;
        }
        public ProductResponse GetProduct(int id)
        {
            var productIntegration = _productIntegration.GetProduct(id);
            if (!_productIntegration.IsProductExist(productIntegration))
                throw new ProductNotFoundException($"Product {id} doesn't exist");
            return new ProductResponse()
            {
                ProductName = productIntegration.Name,
                ProductValue = (decimal)productIntegration.Value
            };
        }

        public bool IsProductExist(int id)
        {
            return _productIntegration.IsProductExist(id);
        }
    }
}
