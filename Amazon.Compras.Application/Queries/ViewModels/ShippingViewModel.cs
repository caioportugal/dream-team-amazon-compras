using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Compras.Application.Queries.ViewModels
{
    public class ShippingViewModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int ShippingValue { get; set; }
    }
}
