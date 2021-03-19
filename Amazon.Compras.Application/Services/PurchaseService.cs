using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Compras.Application.Queries.ViewModels;
using Amazon.Compras.Domain;

namespace Amazon.Compras.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<PurchaseDataViewModel> GetPurchaseData(int purchaseId)
        {
            PurchaseDataViewModel purchaseDataViewModel = null;
            var purchase = await _purchaseRepository.GetPurchaseData(purchaseId);

            if (purchase != null)
            {
                purchaseDataViewModel = new PurchaseDataViewModel()
                {
                    PurchaseItems = MappingCompraProdutoParaItensCompra(purchase.CompraProduto.ToList())
                    
                };
                purchaseDataViewModel.TotalValue = purchaseDataViewModel.PurchaseItems.Sum(x => x.ProductValue);
            }
            return purchaseDataViewModel;
        }

        private List<ProductPurchaseViewModel> MappingCompraProdutoParaItensCompra(List<CompraProduto> compraProduto)
        {
            var listProductPurchase = new List<ProductPurchaseViewModel>();

            foreach(var produto in compraProduto)
            {
                listProductPurchase.Add(new ProductPurchaseViewModel()
                {
                    ProductName = "XPTO",
                    ProductValue = 10.0M
                });
            }
            return listProductPurchase;
        }
    }
}
