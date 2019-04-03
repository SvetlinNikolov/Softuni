using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materialDict = new Dictionary<string, int>();
            var junkElements = new Dictionary<string, int>();

            materialDict["shards"] = 0;
            materialDict["fragments"] = 0;
            materialDict["motes"] = 0;

            string[] inputItems = Console.ReadLine().ToLower().Split().ToArray();
            bool haveWinner = false;

            while (haveWinner == false)
            {

                for (int i = 0; i < inputItems.Length; i += 2)
                {
                    string typeOfItem = inputItems[i + 1];
                    int valueOfItem = int.Parse(inputItems[i]);

                    if (typeOfItem == "shards")
                    {
                        materialDict["shards"] += valueOfItem;
                    }
                    else if (typeOfItem == "fragments")
                    {
                        materialDict["fragments"] += valueOfItem;
                    }
                    else if (typeOfItem == "motes")
                    {
                        materialDict["motes"] += valueOfItem;
                    }
                    else
                    {
                        if (junkElements.ContainsKey(typeOfItem))
                        {
                            junkElements[typeOfItem] += valueOfItem;
                        }
                        else
                        {
                            junkElements.Add(typeOfItem, valueOfItem);
                        }
                    }

                    if (materialDict["shards"] >= 250 ||
                        materialDict["motes"] >= 250 ||
                        materialDict["fragments"] >= 250)
                    {

                        haveWinner = true;
                        if (typeOfItem == "shards")
                        {
                            materialDict["shards"] -= valueOfItem;
                            Console.WriteLine("Shadowmourne obtained!");

                            break;
                        }
                        else if (typeOfItem == "fragments")
                        {
                            materialDict["fragments"] -= valueOfItem;
                            Console.WriteLine("Valanyr obtained!");

                            break;
                        }
                        else if (typeOfItem == "motes")
                        {
                            materialDict["motes"] -= valueOfItem;
                            Console.WriteLine("Dragonwrath obtained!");

                            break;
                        }

                    }
                }

            }
            foreach (var items in materialDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{items.Key}: {items.Value}");

            }
            foreach (var item in junkElements.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
