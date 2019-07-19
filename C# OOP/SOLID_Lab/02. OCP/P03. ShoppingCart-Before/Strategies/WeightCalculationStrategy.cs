using P03._ShoppingCart;
using P03._ShoppingCart_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before.Strategies
{
    public class WeightCalculationStrategy : IPriceCalculationStrategy
    {
        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 4m / 1000;
        }

        public bool IsMatch(OrderItem item)
        {
            if (item.Sku == "WEIGHT")
            {
                return true;
            }
            return false;
        }
    }
}
