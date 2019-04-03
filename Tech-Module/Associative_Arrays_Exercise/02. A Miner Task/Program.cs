using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();

            string command = Console.ReadLine();

            while (command != "stop")
            {
                int value = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(command))
                {
                    dictionary[command] = value;
                }
                else
                {
                    dictionary[command] += value;
                }

                command = Console.ReadLine();
            }
            foreach (var word in dictionary)
            {
                Console.WriteLine($"{word.Key} -> {word.Value}");
            }
        }
    }
}
