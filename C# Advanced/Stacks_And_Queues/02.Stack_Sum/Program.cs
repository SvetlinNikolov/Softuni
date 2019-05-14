using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(inputNumbers);

            string[] command = Console.ReadLine().ToLower().Split().ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    int firstNumber = int.Parse(command[1]);
                    int secondNumber = int.Parse(command[2]);

                    numbers.Push(firstNumber);
                    numbers.Push(secondNumber);
                }

                else if (command[0] == "remove")
                {
                    if (int.Parse(command[1]) <= numbers.Count())
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower().Split().ToArray();

            }
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
