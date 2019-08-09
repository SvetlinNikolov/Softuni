using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Entities
{
    public class Alcohol : Drink, IDrink
    {
        private const decimal AlcoholPrice = 3.50m;
        public Alcohol(string name, int servingSize,  string brand) 
            : base(name, servingSize, AlcoholPrice, brand)
        {
        }
    }
}
