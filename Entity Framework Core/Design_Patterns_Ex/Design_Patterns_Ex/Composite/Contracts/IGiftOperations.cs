using Composite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Contracts
{
    interface IGiftOperations
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
