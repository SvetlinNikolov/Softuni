namespace P03._ShoppingCart
{
    using P03._ShoppingCart_Before.Contracts;
    using P03._ShoppingCart_Before.Strategies;
    using System.Collections.Generic;

    public class Cart
    {
        private readonly List<OrderItem> items;
        private readonly List<IPriceCalculationStrategy> priceCalculationStrategies;
        public Cart()
        {
            this.items = new List<OrderItem>();

            this.priceCalculationStrategies = new List<IPriceCalculationStrategy>()
            {
                new EachCalculationStrategy(),
                new SpecialItemCalculationStrategy(),
                new WeightCalculationStrategy()
            };

        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;

            foreach (var item in this.items)
            {

                foreach (var strategy in priceCalculationStrategies)
                {
                    if (strategy.IsMatch(item))
                    {
                        total += strategy.CalculatePrice(item);
                    }
                }


                // more rules are coming!
            }

            return total;
        }
    }
}
