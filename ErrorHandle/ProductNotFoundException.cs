using System;

namespace Amazon.Purchases.ErrorHandle
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() {}

        public ProductNotFoundException(string message) : base(message) {}

        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException) {}

    }
}
