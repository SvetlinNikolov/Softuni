using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var ordersDict = new Dictionary<string, List<double>>();


            while (true)
            {
                string[] items = Console.ReadLine().Split().ToArray();

                if (items[0] == "buy")
                {
                    break;
                }

                string order = items[0];
                double price = double.Parse(items[1]);
                double quantity = double.Parse(items[2]);

                if (!ordersDict.ContainsKey(order))
                {
                    ordersDict.Add(order, new List<double>());
                    ordersDict[order].Add(price);
                    ordersDict[order].Add(quantity);
                    //itemsCount.Add(order, quantity);
                }
                else
                {
                    ordersDict[order][0] = price;
                    ordersDict[order][1] += quantity;
                }
            }
            foreach (var kvp in ordersDict)
            {
                double totalPrice = kvp.Value[0] * kvp.Value[1];
                Console.WriteLine($"{kvp.Key} -> {totalPrice:f2}");
            }

        }
    }
}

