using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<char> firstHalf = new Queue<char>();
            Stack<char> secondHalf = new Stack<char>();


            for (int i = 0; i < input.Length / 2; i++)
            {
                firstHalf.Enqueue(input[i]);
            }
            for (int i = input.Length / 2; i < input.Length; i++)
            {
                secondHalf.Push(input[i]);

            }
            for (int i = 0; i < firstHalf.Count; i++)
            {
                if (firstHalf.Peek() == '{')
                {
                    if (secondHalf.Peek() != '}')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (firstHalf.Peek() != '[')
                {
                    if (secondHalf.Peek() == ']')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (firstHalf.Peek() == '(')
                {
                    if (secondHalf.Peek() != ')')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                firstHalf.Dequeue();
                secondHalf.Pop();
            }
            Console.WriteLine("YES");
        }
    }
}
