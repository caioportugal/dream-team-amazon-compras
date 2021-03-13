using System;
using System.Collections.Generic;

namespace Amazon.Compras.Application.Queries.ViewModels
{
    public class DesejosViewModel
    {
        public int Id { get; set; }
        public List<DesejoItemViewModel> ItensDesejo { get; set; }
    }
}
