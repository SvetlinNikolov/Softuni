using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _02.On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialInput = Console.ReadLine();
            string[] input = initialInput.Split("->").ToArray();

            string item = string.Empty;
            var dictionary = new Dictionary<string, List<string>>();

            while (initialInput != "END")
            {
                string command = input[0];
                string store = input[1];

                if (input.Length > 2)
                {
                    item = input[2];
                }

                if (command == "Add" && !item.Contains(','))
                {
                    if (!dictionary.ContainsKey(store))
                    {
                        dictionary.Add(store, new List<string>());
                        dictionary[store].Add(item);
                    }
                    else if (dictionary.ContainsKey(store))
                    {
                        dictionary[store].Add(item);
                    }
                }
                else if (command == "Add")
                {
                    if (!dictionary.ContainsKey(store))
                    {
                        dictionary.Add(store, new List<string>());

                        string[] items = input[2].Split(',').ToArray();

                        for (int i = 0; i < items.Length; i++)
                        {
                            dictionary[store].Add(items[i]);
                        }
                    }
                    else if (dictionary.ContainsKey(store))
                    {
                        string[] items = input[2].Split(',').ToArray();

                        for (int i = 0; i < items.Length; i++)
                        {
                            dictionary[store].Add(items[i]);
                        }

                    }
                }
                else if (command == "Remove")
                {
                    if (dictionary.ContainsKey(store))
                    {
                        dictionary.Remove(store);
                    }
                }

                initialInput = Console.ReadLine();
                input = initialInput.Split("->").ToArray();
            }
            Console.WriteLine("Stores list:");

            foreach (var store in dictionary.OrderByDescending(x => x.Value.Count).ThenByDescending(x => x.Key))
            {
                Console.WriteLine(store.Key);
                foreach (var items in store.Value)
                {
                    Console.WriteLine($"<<{items}>>");
                }
            }
        }
    }
}