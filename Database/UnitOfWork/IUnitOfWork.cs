using Amazon.Purchases.Database.Repository;
using System;

namespace Amazon.Purchases.Database.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPurchaseRepository PurchaseRepository { get; }
        IWishRepository WishRepository { get; }
        int Complete();
    }
}