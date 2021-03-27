using System.Collections.Generic;

namespace Amazon.Purchases.Integration
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> MyProperty { get; set; }
    }
}