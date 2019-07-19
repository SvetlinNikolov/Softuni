using P03._ShoppingCart;
using P03._ShoppingCart_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before.Strategies
{
    public class EachCalculationStrategy : IPriceCalculationStrategy
    {
        public decimal CalculatePrice(OrderItem item)
        {
            decimal total = item.Quantity * 5m;

            return total;
        }

        public bool IsMatch(OrderItem item)
        {
            if (item.Sku == "EACH")
            {
                return true;
            }
            return false;

        }

       
    }
}
