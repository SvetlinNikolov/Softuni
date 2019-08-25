using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Numbers_with_a_Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(input);

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
