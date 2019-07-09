
namespace _03._Shopping_Spree
{

    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;

        private decimal money;

        private List<Product> bag;

        private Person()
        {
            bag = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;

        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Exceptions.EmptyNameException);
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Exceptions.InvalidMoneyValueException);
                }

                money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.Money -= product.Cost;
                bag.Add(product);
            }
            else
            {
                throw new ArgumentException(string.Format
                    (Exceptions.NotEnoughMoneyException, this.name, product.Name));
            }
        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.name} - Nothing bought";
            }

            return $"{this.name} - {string.Join(", ", bag)}";
        }

    }
}
