using SoftUniRestaurant.Core.Contracts;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Drinks.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core.Factories
{
    public class DrinkFactory : IDrinkFactory
    {
        public IDrink CreatedDrink(string drinkType,
            string drinkName,
            int drinkServingSize,
            string drinkBrand)

        {
            IDrink drinkToCreate = null;

            switch (drinkType.ToLower())
            {
                case "alcohol":
                    drinkToCreate = new Alcohol(drinkName, drinkServingSize, drinkBrand);
                    break;
                case "fuzzydrink":
                    drinkToCreate = new FuzzyDrink(drinkName, drinkServingSize, drinkBrand);
                    break;
                case "juice":
                    drinkToCreate = new Juice(drinkName, drinkServingSize, drinkBrand);
                    break;
                case "water":
                    drinkToCreate = new Water(drinkName, drinkServingSize, drinkBrand);
                    break;

            }
            return drinkToCreate;

        }
    }
}
