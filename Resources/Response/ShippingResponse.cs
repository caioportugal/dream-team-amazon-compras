namespace Amazon.Purchases.ViewModel
{
    public class ShippingResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int ShippingValue { get; set; }
    }
}
