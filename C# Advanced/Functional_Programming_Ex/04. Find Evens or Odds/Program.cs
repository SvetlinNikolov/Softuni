using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int start = bounds[0];
            int end = bounds[1];

            string oddOrEven = Console.ReadLine();

            Predicate<int> isOddOrEven = x => oddOrEven == "odd" ? x % 2 != 0 : x % 2 == 0;

            List<int> result = new List<int>();

            for (int i = start; i <= end; i++)
            {
                result.Add(i);
            }
            Console.WriteLine(string.Join(" ",result.Where(x=>isOddOrEven(x))));
        }
    }
}
