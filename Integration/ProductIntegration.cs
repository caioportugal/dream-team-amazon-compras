using Amazon.Purchases.Constants;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Amazon.Purchases.Integration
{
    public class ProductIntegration : IProductIntegration
    {
        public Product GetProduct(int id)
        {
            var client = new RestClient(Environment.GetEnvironmentVariable(EnvironmentVariable.ProductURL));
            var url = Environment.GetEnvironmentVariable(EnvironmentVariable.ProductURL) + "product/" + id;
            Console.WriteLine(url);
            var request = new RestRequest($"product/{id}", DataFormat.Json);
            var response = client.Get<Product>(request);
            return (response.Content == null) ?
                   null : 
                   JsonConvert.DeserializeObject<Product>(response.Content);
        }

        public bool IsProductExist(int id) => IsProductExist(GetProduct(id));
        public bool IsProductExist(Product product) => product != null && product.Id != 0;
    }
}
