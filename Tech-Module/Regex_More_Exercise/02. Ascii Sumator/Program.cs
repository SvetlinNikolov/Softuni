using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());

            string range = Console.ReadLine();

            int result = 0;

            int start = Math.Min(startChar, endChar);
            int end = Math.Max(startChar, endChar);

            for (int i = 0; i < range.Length; i++)
            {
                int currentChar = range[i];
                if (currentChar > start && currentChar < end)
                {
                    result += currentChar;
                }
            }
            Console.WriteLine(result);
        }
    }
}
