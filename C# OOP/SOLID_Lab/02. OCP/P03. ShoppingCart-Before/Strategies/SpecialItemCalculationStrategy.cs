using P03._ShoppingCart;
using P03._ShoppingCart_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before.Strategies
{
    public class SpecialItemCalculationStrategy : IPriceCalculationStrategy
    {
        public decimal CalculatePrice(OrderItem item)
        {
            decimal specialPrice = item.Quantity * 0.4m;

            decimal setsOfThree = item.Quantity / 3;

            specialPrice -= setsOfThree * .2m;

            return specialPrice;
        }

        public bool IsMatch(OrderItem item)
        {
            if (item.Sku == "Special")
            {
                return true;
            }
            return false;
        }
    }
}
