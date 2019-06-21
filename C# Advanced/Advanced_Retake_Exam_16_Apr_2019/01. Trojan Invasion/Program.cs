using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();

            Stack<int> warriors = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                int[] currentWarriors = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (i % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    plates.Add(additionalPlate);
                }
                if (plates.Count == 0)
                {
                    Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                    Console.WriteLine("Warriors left: " + string.Join(", ", warriors));
                    return;
                }
                foreach (var currentWarrior in currentWarriors)
                {
                    warriors.Push(currentWarrior);
                }

                while (plates.Count > 0 && warriors.Count > 0)
                {
                    int currentWarrior = warriors.Pop();
                    int currentPlate = plates[0];

                    if (currentPlate - currentWarrior > 0)
                    {
                        currentPlate -= currentWarrior;
                        plates[0] = currentPlate;
                    }
                    else if (currentPlate - currentWarrior < 0)
                    {
                        currentWarrior -= currentPlate;

                        warriors.Push(currentWarrior);

                        plates.RemoveAt(0);
                    }
                    else if (currentPlate - currentWarrior == 0)
                    {
                        plates.RemoveAt(0);
                    }

                   


                }
            }
            if (warriors.Count == 0)
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", plates));
                return;
            }
            if (plates.Count == 0)
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine("Warriors left: " + string.Join(", ", warriors));
                return;
            }
        }

    }
}



