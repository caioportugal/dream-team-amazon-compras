using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Compras.Domain
{
    public interface IDesejoRepository
    {
        void Adicionar(Desejos desejos);
    }
}
