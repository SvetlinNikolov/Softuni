namespace _06._Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {

            int countClothers = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> clothes
                = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < countClothers; i++)
            {
                string[] currentItem = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = currentItem[0];

                string[] items = currentItem[1].Split
                    (',', StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(color))
                {
                    clothes[color] = new Dictionary<string, List<string>>();
                    foreach (var item in items)
                    {
                        if (!clothes[color].ContainsKey(item))
                        {
                            clothes[color].Add(item, new List<string>());
                        }
                     
                        clothes[color][item].Add(item);
                    }

                }
                else if (clothes.ContainsKey(color))
                {
                    foreach (var item in items)
                    {
                        if (clothes[color].ContainsKey(item))
                        {
                            clothes[color][item].Add(item);
                        }
                        else
                        {
                            clothes[color].Add(item, new List<string>());
                            clothes[color][item].Add(item);
                        }
                       
                    }
                }


            }
            string[] itemsToLookFor = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string itemColor = itemsToLookFor[0];
            string itemToFind = itemsToLookFor[1];

            foreach (var kvp in clothes)
            {
                string currentKey = kvp.Key;

                Console.WriteLine($"{currentKey} clothes:");

                foreach (var element in kvp.Value.ToList())
                {
                    if (itemColor == currentKey && itemToFind == element.Key)
                    {
                        Console.WriteLine($"* {element.Key} - {element.Value.Count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {element.Key} - {element.Value.Count} ");
                    }
                   
                   
                }
            }
            Console.WriteLine();
        }
    }
}
