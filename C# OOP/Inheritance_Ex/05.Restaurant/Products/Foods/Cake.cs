using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products.Foods
{
    public class Cake : Dessert
    {
        public const double Grams = 250;
        public const double Calories = 1000;
        public const decimal CakePrice = 5M;

        public Cake(string name, decimal price, double grams, double calories)
            : base(name, CakePrice, Grams, Calories)
        {
        }
    }
}
