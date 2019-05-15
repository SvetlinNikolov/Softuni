using System;
using System.Linq;
using System.Collections.Generic;
namespace _01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersForStack = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numbersToPush = numbersForStack[0];
            int numbersToPop = numbersForStack[1];
            int numbersToFind = numbersForStack[2];

            int[] numbersInStack = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbersToPush; i++)
            {
                if (numbersInStack.Length > i)
                {
                    stack.Push(numbersInStack[i]);
                }
            }
            for (int j = 0; j < numbersToPop; j++)
            {
                if (numbersInStack.Length > j)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(numbersToFind))
            {
                Console.WriteLine("true");
            }
            else
            {

                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
    

