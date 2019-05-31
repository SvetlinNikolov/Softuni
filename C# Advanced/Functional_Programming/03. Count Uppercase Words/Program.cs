using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Func<string, bool> upperMaker = n => n[0] == n.ToUpper()[0];

            var result = text
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Where(upperMaker)
                 .ToArray();

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}
