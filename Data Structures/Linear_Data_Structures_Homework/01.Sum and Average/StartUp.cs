using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sum_and_Average
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Console.WriteLine($"Sum={numbers.Sum()}; Average={numbers.Average():f2}");
        }
    }
}
