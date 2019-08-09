using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core.Contracts
{
    public interface IDrinkFactory
    {
        IDrink CreatedDrink(string drinkType, string drinkName, int drinkServingSize,string drinkBrand);
    }
}
