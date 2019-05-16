using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Queue<int> petrolQueue = new Queue<int>();

            Queue<int> kilometersQueue = new Queue<int>();

            int tankCapacity = 0;

            for (int i = 0; i < numberOfInputs; i++)
            {
                int[] petrolAndKilometers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                petrolQueue.Enqueue(petrolAndKilometers[0]);
                kilometersQueue.Enqueue(petrolAndKilometers[1]);
            }

            while (kilometersQueue.Count > 0)
            {
                if (petrolQueue.Peek() > kilometersQueue.Peek())
                {
                    tankCapacity = tankCapacity + petrolQueue.Dequeue() - kilometersQueue.Dequeue();

                }
            }






        }
    }
}
