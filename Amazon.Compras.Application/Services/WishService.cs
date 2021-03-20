using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.Compras.Application.Queries.ViewModels;
using Amazon.Compras.Domain;

namespace Amazon.Purchases.Application.Services
{
    public class WishService : IWishService
    {
        private IWishRepository _wishRepository;

        public WishService(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }

        public async Task<bool> AddWish(WishesViewModel wishesViewModel)
        {           
            var desejos = new Desejos();
            desejos.ItemDesejo = WhishItemsViewModelToItemDesejo(wishesViewModel.WhishItems);
            _wishRepository.Add(desejos);
            return true;            
        }

        private List<ItemDesejo> WhishItemsViewModelToItemDesejo(List<WhishItemsViewModel> whishItemsViewModel)
        {
            var listaDesejos = new List<ItemDesejo>();
            if (!AnyProductDoesntExists(whishItemsViewModel))
            {
                // TODO
                return null;
            }

            foreach (var item in whishItemsViewModel)
            {
                var itemDesejo = new ItemDesejo();
                itemDesejo.ProdutoId = item.Id;
                listaDesejos.Add(itemDesejo);
            }
            return listaDesejos;
        }

        private bool AnyProductDoesntExists(List<WhishItemsViewModel> whishItemsViewModel)
        {
            return true;
        }
    }
}
