using System.Collections.Generic;

namespace Amazon.Purchases.Integration
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public List<Category> Category { get; set; }
        public List<string> KeyWords { get; set; }
    }
}
