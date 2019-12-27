using Drinks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks.Data.Contracts
{
    public interface IDrinkRepository
    {
         IEnumerable<Drink> Drinks { get;  }
        IEnumerable<Drink> PreferredDrinks { get; }
        Drink GetDrinkById(int id);

    }
}
