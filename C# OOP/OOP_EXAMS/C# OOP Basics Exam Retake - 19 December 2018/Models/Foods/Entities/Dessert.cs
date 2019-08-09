using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Entities
{
    public class Dessert : Food, IFood
    {
        private const int InitialServingSize = 200;
        public Dessert(string name, decimal price) 
            : base(name, InitialServingSize, price)
        {

        }
    }
}
