using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Entities
{
    public class MainCourse : Food, IFood
    {
        private const int InitialServingSize = 500;
        public MainCourse(string name,  decimal price) 
            : base(name, InitialServingSize, price)
        {

        }
    }
}
