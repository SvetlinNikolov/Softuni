using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Entities
{
    public class Juice : Drink, IDrink
    {
        private const decimal JuicePrice = 1.80m;
        public Juice(string name, int servingSize, string brand) 
            : base(name, servingSize, JuicePrice, brand)
        {
        }
    }
}
