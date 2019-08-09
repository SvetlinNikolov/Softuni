﻿using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Entities
{
    public class Water : Drink, IDrink
    {
        private const decimal WaterPrice = 1.50m;
        public Water(string name, int servingSize, string brand) 
            : base(name, servingSize, WaterPrice, brand)
        {
        }
    }
}
