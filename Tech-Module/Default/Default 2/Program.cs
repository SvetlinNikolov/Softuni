using System;
using System.Collections.Generic;
using System.Linq;
namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('#', '=').ToList();
            int water = int.Parse(Console.ReadLine());
            List<int> validCells = new List<int>();
            int totalFire = 0;
            double effort = 0;

            for (int i = 0; i < input.Count; i += 2)
            {
                string typeOfFire = input[i].Trim();
                int fireValue = int.Parse(input[i + 1]);

                if (typeOfFire == "High" && fireValue >= 81 && fireValue <= 125)
                {
                    if (water - fireValue >= 0)
                    {
                        Penis(ref water, validCells, ref totalFire, ref effort, fireValue);
                    }

                }
                if (typeOfFire == "Medium" && fireValue >= 51 && fireValue <= 80)
                {
                    if (water - fireValue >= 0)
                    {
                        water -= fireValue;
                        totalFire += fireValue;
                        effort += fireValue * 0.25;
                        validCells.Add(fireValue);
                    }
                }
                if (typeOfFire == "Low" && fireValue >= 1 && fireValue <= 50)
                {
                    if (water - fireValue >= 0)
                    {
                        water -= fireValue;
                        totalFire += fireValue;
                        effort += fireValue * 0.25;
                        validCells.Add(fireValue);
                    }
                }
            }
            Console.WriteLine("Cells:");
            foreach (var validCell in validCells)
            {
                Console.WriteLine(" - " + validCell);
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }

        private static void Penis(ref int water, List<int> validCells, ref int totalFire, ref double effort, int fireValue)
        {
            water -= fireValue;
            totalFire += fireValue;
            effort += fireValue * 0.25;
            validCells.Add(fireValue);
        }
    }
}
