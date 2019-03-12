using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;
            int bestRoom = 0;
            List<string> dungeon = Console.ReadLine()
                .Split(' ', '|')
                .ToList();

            for (int i = 0; i < dungeon.Count; i += 2)
            {
                if (health > 0)
                {
                    bestRoom++;
                    if (dungeon[i] == "potion")
                    {
                        int currentHealth = health;
                        health += int.Parse(dungeon[i + 1]);

                        if (health > 100)
                        {
                            Console.WriteLine($"You healed for {100 - currentHealth} hp.");
                            health = 100;
                        }
                        else
                        {
                            Console.WriteLine($"You healed for {int.Parse(dungeon[i + 1])} hp.");
                        }

                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (dungeon[i] == "chest")
                    {
                        coins += int.Parse(dungeon[i + 1]);
                        Console.WriteLine($"You found {int.Parse(dungeon[i + 1])} coins.");
                    }
                    else
                    {
                        health -= int.Parse(dungeon[i + 1]);
                        if (health <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {dungeon[i]}.");
                        }
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {dungeon[i]}.");
                        }
                    }
                }
            }
            if (health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }
            else if (health <= 0)
            {
                Console.WriteLine($"Best room: {bestRoom}");
            }
        }

    }
}