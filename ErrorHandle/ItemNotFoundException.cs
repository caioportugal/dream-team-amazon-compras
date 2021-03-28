﻿using System;

namespace Amazon.Purchases.ErrorHandle
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() {}

        public ItemNotFoundException(string message) : base(message) {}

        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) {}

    }
}
