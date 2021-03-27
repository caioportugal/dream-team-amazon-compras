using Amazon.Purchases.ViewModel;

namespace Amazon.Purchases.Services.Interface
{
    public interface IProductService
    {
        ProductResponse GetProduct(int id);
        bool IsProductExist(int id);
    }
}
