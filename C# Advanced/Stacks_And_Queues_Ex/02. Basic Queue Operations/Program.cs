using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersForQueue = Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToArray();

            int numbersToPush = numbersForQueue[0];
            int numbersToPop = numbersForQueue[1];
            int numbersToFind = numbersForQueue[2];

            int[] numbersInQueue = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numbersToPush; i++)
            {
                if (numbersInQueue.Length > i)
                {
                    queue.Enqueue(numbersInQueue[i]);
                }
            }
            for (int j = 0; j < numbersToPop; j++)
            {
                if (numbersInQueue.Length > j)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(numbersToFind))
            {
                Console.WriteLine("true");
            }
            else
            {

                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}

