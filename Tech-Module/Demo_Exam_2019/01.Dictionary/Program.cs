using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordsAndDefinitions = Console.ReadLine().Split(" | ", ':').ToList();

            var dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < wordsAndDefinitions.Count; i++)
            {
                string[] currentWordAndDef = wordsAndDefinitions[i].Split(": ");

                string word = currentWordAndDef[0];

                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());

                    for (int j = 1; j < currentWordAndDef.Length; j++)
                    {
                        dictionary[word].Add(currentWordAndDef[j]);
                    }
                }
                else if (dictionary.ContainsKey(word))
                {
                    for (int k = 1; k < currentWordAndDef.Length; k++)
                    {
                        dictionary[word].Add(currentWordAndDef[k]);
                    }
                }
            }
            string[] wordsToPrint = Console.ReadLine().Split(" | ").ToArray();

            for (int word = 0; word < wordsToPrint.Length; word++)
            {
                
                if (dictionary.ContainsKey(wordsToPrint[word]))
                {
                    Console.WriteLine(wordsToPrint[word]);
                    foreach (var key in dictionary[wordsToPrint[word]].OrderByDescending(x=>x.Length))
                    {
                            Console.WriteLine(" -"+key);
                    }
                }
            }
            string command = Console.ReadLine();

            if (command == "List")
            {
                foreach (var word in dictionary.Keys.OrderBy(x=>x))
                {
                    Console.Write(word+" ");
                }
            }
        }
    }
}
