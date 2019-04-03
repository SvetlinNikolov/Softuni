using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cooking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int sumOfBreadValues = 0;

            int maxBreadValue = 0;
            string bestBread = "";
            double bestBreadQuality = int.MinValue;
            string tempBreadElementCounter = "";
            int bestCurrentArrayCount = int.MaxValue;

            while (command != "Bake It!")
            {
                
                List<int> breadBatches = command.Split("#")
                    .Select(int.Parse)
                    .ToList();

                for (int i = 0; i < breadBatches.Count; i++)
                {
                    sumOfBreadValues += breadBatches[i];
                    tempBreadElementCounter += breadBatches[i] + " ";
                }

                if (sumOfBreadValues > maxBreadValue)
                {

                    maxBreadValue = sumOfBreadValues;
                    bestBread = tempBreadElementCounter;
                    bestBreadQuality = breadBatches.Average();

                    sumOfBreadValues = 0;
                    tempBreadElementCounter = "";
                    bestCurrentArrayCount = breadBatches.Count;

                    command = Console.ReadLine();
                    continue;
                }

                if (sumOfBreadValues == maxBreadValue)
                {
                    if (breadBatches.Count < bestCurrentArrayCount)
                    {
                        bestBread = tempBreadElementCounter;
                        bestBreadQuality = breadBatches.Average();
                    }
                }

                if (sumOfBreadValues == maxBreadValue)
                {
                    if (breadBatches.Count == bestCurrentArrayCount)
                    {
                        if (breadBatches.Average() > bestBreadQuality)
                        {
                            bestBread = tempBreadElementCounter;
                            bestBreadQuality = breadBatches.Average();
                        }

                    }
                }


                tempBreadElementCounter = "";
                sumOfBreadValues = 0;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {maxBreadValue}");
            Console.WriteLine(bestBread.Trim());
        }
    }
}