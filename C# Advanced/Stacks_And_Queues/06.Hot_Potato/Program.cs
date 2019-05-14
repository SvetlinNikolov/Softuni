using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peoplePlaying = Console.ReadLine().Split();

            int numberOfTosses = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(peoplePlaying);

            while (queue.Count != 1)
            {
                for (int i = 1; i < numberOfTosses; i++)
                {
                  
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
