using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodValue = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (orders.Count>0)
            {
                int currentCustomerOrder = orders.Peek();

                if (foodValue - currentCustomerOrder >= 0)
                {
                    foodValue -= currentCustomerOrder;
                    orders.Dequeue();
                }
                else
                {
                   
                    Console.Write("Orders left: ");
                    Console.Write(string.Join(" ",orders));
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
