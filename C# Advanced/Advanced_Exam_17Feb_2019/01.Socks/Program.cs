using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Exam_17Feb_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] leftSide = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] rightSide = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Stack<int> leftSideSocks = new Stack<int>(leftSide);
            Queue<int> rightSideSocks = new Queue<int>(rightSide);

            List<int> allSetsOfSocks = new List<int>();

            for (int i = 0; i < Math.Max(leftSide.Length, rightSide.Length); i++)
            {
                if (leftSideSocks.Count == 0 || rightSideSocks.Count == 0)
                {
                    break;
                }

                if (leftSideSocks.Peek() > rightSideSocks.Peek())
                {
                    int pairValue = leftSideSocks.Pop() + rightSideSocks.Dequeue();
                    allSetsOfSocks.Add(pairValue);
                }
                else if (rightSideSocks.Peek() > leftSideSocks.Peek())
                {
                    while (leftSideSocks.Count > 0 && rightSideSocks.Count > 0 && rightSideSocks.Peek() > leftSideSocks.Peek())
                    {
                        leftSideSocks.Pop();
                    }
                }
                else if (leftSideSocks.Peek() == rightSideSocks.Peek())
                {
                    rightSideSocks.Dequeue();
                    leftSideSocks.Push(leftSideSocks.Pop() + 1);

                }
            }
            Console.WriteLine(allSetsOfSocks.Max());
            Console.WriteLine(string.Join(" ", allSetsOfSocks));
        }
    }
}
