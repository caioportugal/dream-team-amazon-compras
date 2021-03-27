namespace Amazon.Purchases.Integration
{
    public class ProductIntegration : IProductIntegration
    {
        public Product GetProduct(int id)
        {
            var product = new Product()
            {
                Id = 1,
                Name = "Produto",
                Value = 10
            };
            return product;
        }

        public bool IsProductExist(int id) => IsProductExist(GetProduct(id));
        public bool IsProductExist(Product product) => product != null && product.Id != 0;
    }
}
