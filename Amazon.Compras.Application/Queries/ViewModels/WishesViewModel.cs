using System;
using System.Collections.Generic;

namespace Amazon.Compras.Application.Queries.ViewModels
{
    public class WishesViewModel
    {
        public int Id { get; set; }
        public List<WhishItemsViewModel> WhishItems { get; set; }
    }
}
