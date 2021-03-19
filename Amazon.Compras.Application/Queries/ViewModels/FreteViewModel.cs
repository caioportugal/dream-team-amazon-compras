using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Compras.Application.Queries.ViewModels
{
    public class FreteViewModel
    {
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
        public int ValorFrete { get; set; }
    }
}
