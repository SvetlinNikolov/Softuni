using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dictionary = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (dictionary.ContainsKey(input[i]))
                {

                    dictionary[input[i]]++;
                }
                else
                {
                    dictionary.Add(input[i], 1);
                }
            }
            foreach (var word in dictionary)
            {
                if (word.Key != ' ')
                {
                    Console.WriteLine($"{word.Key} -> {word.Value}");
                }

            }
        }
    }

}
