using Amazon.Purchases.ViewModel;

namespace Amazon.Purchases.Services
{
    public interface IPurchaseService
    {
        PurchaseResponse GetPurchaseData(int purchaseId);
        PurchaseResponse AddPurchase(PurchaseRequest purchase);
        bool IsValidPurchase(int purchaseId);
    }
}