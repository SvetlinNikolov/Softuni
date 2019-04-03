using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.Bread_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> events = Console.ReadLine().Split('-', '|').ToList();
            int energy = 100;
            int coins = 100;

            for (int i = 0; i < events.Count; i += 2)
            {
                if (events[i] == "rest")
                {
                    int currentEnergy = energy;
                    energy += int.Parse(events[i + 1]);
                    if (energy > 100)
                    {
                        Console.WriteLine($"You gained {100 - currentEnergy} energy.");
                        energy = 100;
                    }
                    else
                    {
                        Console.WriteLine($"You gained {int.Parse(events[i + 1])} energy.");
                    }

                    Console.WriteLine($"Current energy: {energy}.");
                    currentEnergy = energy;
                }
                else if (events[i] == "order")
                {
                    if (energy >= 30)
                    {
                        coins += int.Parse(events[i + 1]);
                        Console.WriteLine($"You earned {int.Parse(events[i + 1])} coins.");
                        energy -= 30;
                    }
                    else if (energy < 30)
                    {
                        energy += 50;
                        Console.WriteLine("You had to rest!");
                    }

                }

                else
                {
                    if (coins < int.Parse(events[i + 1]))
                    {
                        Console.WriteLine($"Closed! Cannot afford {events[i]}.");
                        coins -= int.Parse(events[i + 1]);
                        break;
                    }
                    if (coins >= int.Parse(events[i + 1]))
                    {
                        Console.WriteLine($"You bought {events[i]}.");
                        coins -= int.Parse(events[i + 1]);
                    }
                }
            }
            if (coins >= 0)
            {
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {energy}");
            }
        }
    }
}