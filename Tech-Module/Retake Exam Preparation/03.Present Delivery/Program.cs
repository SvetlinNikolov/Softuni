using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@").Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();
            int sumOfPresents = 0;
            
            int santaIndex = 0;

            while (command[0] != "Merry")
            {
                int timesToJump = int.Parse(command[1]);
                
                if (santaIndex + timesToJump >= houses.Count)
                {
                    santaIndex = (santaIndex + timesToJump) % houses.Count;
                }
                else
                {
                    santaIndex += timesToJump;
                }

                if (houses[santaIndex]>0)
                {
                    houses[santaIndex] -= 2;
                }
                else
                {
                    Console.WriteLine($"House {santaIndex} will have a Merry Christmas.");
                }

                command = Console.ReadLine().Split().ToArray();
            }
            int failedHouses = houses.Where(x => x != 0).Count();

            foreach (var housePresents in houses)
            {
                sumOfPresents += housePresents;
            }
            if (sumOfPresents == 0)
            {
                Console.WriteLine($"Santa's last position was {santaIndex}.");
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa's last position was {santaIndex}.");
                Console.WriteLine($"Santa has failed {failedHouses} houses.");
               
            }
        }

    }
}
