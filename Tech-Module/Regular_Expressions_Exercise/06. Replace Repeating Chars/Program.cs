using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequenceOfLetters = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < sequenceOfLetters.Length - 1; i++)
            {
                if (sequenceOfLetters[i] != sequenceOfLetters[i + 1])
                {
                    result += sequenceOfLetters[i];

                }
            }
            Console.WriteLine(result + sequenceOfLetters.Last());
        }
    }
}
