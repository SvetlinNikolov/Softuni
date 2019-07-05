using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        public const int Grams = 22;

        public Fish(string name, decimal price, double grams)
            : base(name, price, Grams)
        {
           
        }
    }
}
