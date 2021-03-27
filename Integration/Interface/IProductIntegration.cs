namespace Amazon.Purchases.Integration
{
    public interface IProductIntegration
    {
        Product GetProduct(int id);
        bool IsProductExist(int id);
        bool IsProductExist(Product product);
    }
}
