﻿using Amazon.Purchases.Database;
using Amazon.Purchases.Database.UnitOfWork;
using Amazon.Purchases.ErrorHandle;
using Amazon.Purchases.Model;
using Amazon.Purchases.Resources.Response;
using Amazon.Purchases.Services.Interface;
using Amazon.Purchases.ViewModel;
using System.Collections.Generic;

namespace Amazon.Purchases.Services
{
    public class WishService : IWishService
    {
        private PurchaseContext _context;
        private IProductService _productService;
        public WishService(PurchaseContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public WishResponse AddWish(WishRequest wishesViewModel)
        {
            var wish = new Wish();
            using (var unitOfWork = new UnitOfWork(_context))
            {
                wish.WishItem = WishItemsViewModelToWishtemItem(wishesViewModel.WishItems);
                unitOfWork.WishRepository.Add(wish);
                unitOfWork.Complete();
            }
            return MapWish(wish);
        }

        public WishResponse GetWish(int id)
        {
           var wish = new Wish();
           using(var unitOfWork = new UnitOfWork(_context))
           {
                wish = unitOfWork.WishRepository.GetWish(id);
           }
            if (wish == null)
                throw new ItemNotFoundException($"Wish {id} doesn't exist");
           return MapWish(wish);
        }

        private List<WishItem> WishItemsViewModelToWishtemItem(List<WishItemsRequest> wishItemRequest)
        {
            if (!AreAllProductsExists(wishItemRequest))
                throw new ItemNotFoundException("All products must exists");
            var wishes = new List<WishItem>();
            foreach (var wish in wishItemRequest)
            {
                wishes.Add(new WishItem()
                {
                    ProductId = wish.ProductId
                });
            }
            return wishes;
        }

        private bool AreAllProductsExists(List<WishItemsRequest> wishItemRequest)
        {
            foreach (var wish in wishItemRequest)
            {
                if (!_productService.IsProductExist(wish.ProductId))
                    return false;
            }
            return true;
        }

        private WishResponse MapWish(Wish wish)
        {
            var wishResponse = new WishResponse()
            {
                Id = wish.Id,
                Product = new List<ProductResponse>()                
            };            
            foreach (var product in wish.WishItem)
            {
                wishResponse.Product.Add(_productService.GetProduct(product.ProductId));
            }
            return wishResponse;
        }
    }
}
