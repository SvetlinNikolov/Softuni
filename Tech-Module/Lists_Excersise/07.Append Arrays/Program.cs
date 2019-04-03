using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputArray = Console.ReadLine().Split('|').Reverse()
                .ToList();

            var numbers = new List<int>();

            foreach (var str in inputArray)
            {
                numbers.AddRange(str.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse));
            }
            Console.WriteLine(string.Join(" ",numbers));

        }
    }
}
