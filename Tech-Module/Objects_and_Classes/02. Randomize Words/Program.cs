using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _02.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            Random rnd = new Random();
            List<string> shuffledWords = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                int wordToSwitch = rnd.Next(0, shuffledWords.Count + 1);
                shuffledWords.Insert(wordToSwitch, words[i]);

            }
            foreach (var item in shuffledWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
