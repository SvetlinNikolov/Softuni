using System;
using System.Collections.Generic;
using System.Linq;
namespace Test_Projects_Here
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reverseStack = new Stack<char>(input);

            while (reverseStack.Count != 0)
            {
                Console.Write(reverseStack.Pop());
            }
        }
    }
}
