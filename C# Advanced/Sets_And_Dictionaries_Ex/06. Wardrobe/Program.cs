namespace _06._Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            //UNFINISHED
            int countClothers = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> clothes = new Dictionary<string, List<string>>();

            for (int i = 0; i < countClothers; i++)
            {
                string[] currentItem = Console.ReadLine()
                    .Split(" -> ", ',', StringSplitOptions.RemoveEmptyEntries);

                string color = currentItem[0];

                string[] items = currentItem[1].Split
                    (',', StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(color))
                {
                    clothes[color] = new List<string>();
                    foreach (var item in items)
                    {
                        clothes[color].Add(item);
                    }

                }
                else if (clothes.ContainsKey(color))
                {
                    foreach (var item in items)
                    {
                        clothes[color].Add(item);
                    }
                }

            }
            string[] itemsToSearchFor = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string colorToFind = itemsToSearchFor[0];
            string itemToFind = itemsToSearchFor[1];

            foreach (var kvp in clothes)
            {
                string currentColor = kvp.Key;

                Console.WriteLine($"{currentColor} clothes:");

                foreach (var item in kvp.Value.ToList())
                {
                    if (kvp.Value.ToList().Count < 1)
                    {
                        break;
                    }
                    int counter = 0;

                    while (clothes[currentColor].Contains(item))
                    {
                        counter++;
                        clothes[currentColor].Remove(item);
                    }
                    if (currentColor == colorToFind && item == itemToFind)
                    {
                        Console.WriteLine($"* {item} - {counter} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {item} - {counter}");
                }
            }
            
        }
    }
}
