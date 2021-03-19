using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Compras.Domain
{
    public interface IWishRepository
    {
        void Add(Desejos wish);
    }
}
