using System;
using System.Linq;
using System.Collections.Generic;
namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> addOneToAll = x => x.Select(a => a += 1).ToList();
            Func<List<int>, List<int>> multiplyAllByTwo = x => x.Select(a => a *= 2).ToList();
            Func<List<int>, List<int>> subtractOneFromAll = x => x.Select(a => a -= 1).ToList();

            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));

            List<int> numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                else if (command == "add")
                {
                    numbers = addOneToAll(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiplyAllByTwo(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtractOneFromAll(numbers);
                }

            }
        }
    }
}
