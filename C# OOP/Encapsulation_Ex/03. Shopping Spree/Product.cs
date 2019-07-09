

using System;
using System.Collections.Generic;

namespace _03._Shopping_Spree
{
    public class Product
    {

        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;

        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Exceptions.EmptyNameException);
                }
                name = value;
            }
        }
        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Exceptions.InvalidMoneyValueException);
                }
                cost = value;
            }
        }
        public override string ToString()
        {
            return $"{this.name}";
        }


    }
}
