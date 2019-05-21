
namespace _03._Product_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] commands = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Revision")
                {
                    break;
                }
                string shop = commands[0];
                string product = commands[1];
                double price = double.Parse(commands[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                    shops[shop].Add(product, price);
                }
                else if (shops.ContainsKey(shop))
                {
                    shops[shop].Add(product, price);
                }

            }
            foreach (var kvp in shops.OrderBy(x=>x.Key))
            {
                string currentShop = kvp.Key;
                Console.WriteLine(currentShop+"->");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }

            }
        }
    }
}
