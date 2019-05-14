using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsThatPass = int.Parse(Console.ReadLine());

            string commands = Console.ReadLine();

            int carsThatPassedCount = 0;
            Queue<string> carsinQueue = new Queue<string>();

            while (commands != "end")
            {
                if (commands == "green")
                {
                    for (int i = 0; i < carsThatPass; i++)
                    {
                        if (carsinQueue.Count > 0)
                        {
                            carsThatPassedCount++;
                            Console.WriteLine(carsinQueue.Dequeue() + " passed!");
                         
                        }
                    }
                }
                if (commands != "green")
                {
                    carsinQueue.Enqueue(commands);
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine($"{carsThatPassedCount} cars passed the crossroads.");
        }
    }
}
