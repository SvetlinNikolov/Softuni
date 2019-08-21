using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Count_Of_Occurences
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersStored = new Dictionary<int, int>();

            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (!numbersStored.ContainsKey(inputNumbers[i]))
                {
                    numbersStored[inputNumbers[i]] = 1;
                }
                else
                {
                    numbersStored[inputNumbers[i]]++;
                }
            }
            foreach (var (value, count) in numbersStored.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{value} -> {count} times");
            }


            for (int i = 0; i < inputNumbers.Length; i++)
            {
                int counter = 1;
                for (int j = i + 1; j < inputNumbers.Length - 1; j++)
                {
                    if (i == j)
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"{i} -> {counter} times");
                
            }
        }
    }
}
