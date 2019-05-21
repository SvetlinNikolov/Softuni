using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<double, List<double>>();

            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!dict.ContainsKey(numbers[i]))
                {
                    dict[numbers[i]] = new List<double>();
                    dict[numbers[i]].Add(numbers[i]);
                }
                else if (dict.ContainsKey(numbers[i]))
                {
                    dict[numbers[i]].Add(numbers[i]);
                }
            }

            foreach (var kvp in dict)
            {
                double key = kvp.Key;
                List<double> value = kvp.Value;

                Console.WriteLine($"{key} - {value.Count} times");
            }
        }
    }
}
