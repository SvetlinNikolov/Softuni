
namespace _05._Count_Symbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, List<char>> symbolCounter = new Dictionary<char, List<char>>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!symbolCounter.ContainsKey(text[i]))
                {
                    symbolCounter[text[i]] = new List<char>();
                    symbolCounter[text[i]].Add(text[i]);
                }
                else if (symbolCounter.ContainsKey(text[i]))
                {
                    symbolCounter[text[i]].Add(text[i]);
                }
            }
            foreach (var kvp in symbolCounter.OrderBy(x=>x.Key))
            {
                char currentSymbol = kvp.Key;

                Console.WriteLine($"{currentSymbol}: {kvp.Value.Count} time/s");

            }
        }
    }
}
