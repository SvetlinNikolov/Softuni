using System;
using System.Linq;
using System.Collections.Generic;
namespace _06._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNums = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();

            int divisionNumber = int.Parse(Console.ReadLine());

            List<int> result = new List<int>();

            Predicate<int> canDivide = x => x % divisionNumber != 0;

            Console.WriteLine(string.Join(" ",inputNums.Where(x=>canDivide(x)).Reverse()));
        }
    }
}
