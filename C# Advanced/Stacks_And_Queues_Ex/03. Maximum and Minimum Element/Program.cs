using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            Stack<int> queries = new Stack<int>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    queries.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    if (queries.Count > 0)
                    {
                        queries.Pop();
                    }
                }
                else if (input[0] == 3)
                {
                    if (queries.Count > 0)
                    {
                        Console.WriteLine(queries.Max());
                    }

                }
                else if (input[0] == 4)
                {
                    if (queries.Count > 0)
                    {
                        Console.WriteLine(queries.Min());
                    }
                }

            }

            Console.Write(string.Join(", ", queries));

        }
    }
}
