using Drinks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks.Data.Contracts
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
