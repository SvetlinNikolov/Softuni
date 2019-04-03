using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            var count = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string wordToLower = words[i].ToLower();
                if (count.ContainsKey(wordToLower))
                {
                    count[wordToLower]++;
                }
                else
                {
                    count.Add(wordToLower, 1);
                }
            }
            foreach (var word in count)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write($"{word.Key} ");
                }
            }

        }
    }
}
