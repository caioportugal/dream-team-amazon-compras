using Amazon.Purchases.Database;
using Amazon.Purchases.Database.UnitOfWork;
using Amazon.Purchases.ErrorHandle;
using Amazon.Purchases.Model;
using Amazon.Purchases.Services.Interface;
using Amazon.Purchases.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amazon.Purchases.Services
{
    public class PurchaseService : IPurchaseService
    {
        private PurchaseContext _context;
        private IProductService _productService;
        public PurchaseService(PurchaseContext context, IProductService productService)
        {
            _productService = productService;
            _context = context;
        }

        public PurchaseResponse AddPurchase(PurchaseRequest purchaseRequest)
        {
            var purchase = new Purchase()
            {
                PurchaseProduct = CreatePurchaseProduct(purchaseRequest.ProductId)
            };
            using (var unitOfWork = new UnitOfWork(_context))
            {
                unitOfWork.PurchaseRepository.Add(purchase);
                unitOfWork.Complete();
            }
            return MappingPurchaseReponse(purchase);
        }

        public PurchaseResponse GetPurchaseData(int purchaseId)
        {
            var purchase = new Purchase();
            using (var unitOfWork = new UnitOfWork(_context))
            {
                purchase = unitOfWork.PurchaseRepository.GetPurchase(purchaseId);

            }
            if (purchase == null)
                throw new ItemNotFoundException($"Purchase {purchaseId} doesn't exist");
            return MappingPurchaseReponse(purchase);
        }

        private List<ProductResponse> MappingProduct(List<PurchaseProduct> products)
        {
            var listProductPurchase = new List<ProductResponse>();
            foreach (var product in products)
            {
                var productResponse = _productService.GetProduct(product.ProductId);
                productResponse.ProductValue = product.ProductValue;
                listProductPurchase.Add(productResponse);
            }
            return listProductPurchase;
        }

        private ICollection<PurchaseProduct> CreatePurchaseProduct(List<int> ProductsId)
        {
            var purchaseProducts = new List<PurchaseProduct>();
            foreach (var productId in ProductsId)
            {
                var productIntegration = _productService.GetProduct(productId);
                purchaseProducts.Add(new PurchaseProduct()
                {
                    ProductId = productId,
                    ProductValue = productIntegration.ProductValue,
                });
            }
            return purchaseProducts;
        }

        private PurchaseResponse MappingPurchaseReponse(Purchase purchase)
        {
            if (purchase == null)
                return null;
            var purchaseReponse = new PurchaseResponse()
            {
                PurchaseId = purchase.Id,
                Products = MappingProduct(purchase.PurchaseProduct.ToList())
            };
            purchaseReponse.TotalValue = purchaseReponse.Products.Sum(x => x.ProductValue);
            return purchaseReponse;
        }

        public bool IsValidPurchase(int purchaseId)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                return unitOfWork.PurchaseRepository.IsPurchaseExist(purchaseId);
            }
        }
    }
}