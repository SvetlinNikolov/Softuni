using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int valueOfIntel = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> lockQueue = new Queue<int>(locks);

            int costOfBullets = 0;

            int magazineCounter = gunBarrelSize;

            while (true)
            {
                if (bulletStack.Count == 0 && lockQueue.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
                    break;
                }
                if (lockQueue.Count == 0)
                {
                    if (magazineCounter == 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                    Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${valueOfIntel - costOfBullets}");
                    break;
                }
                if (bulletStack.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left:{lockQueue.Count}");
                    break;
                }

                if (magazineCounter > 0)
                {
                    costOfBullets += bulletPrice;
                    magazineCounter--;

                    if (bulletStack.Peek() <= lockQueue.Peek())
                    {
                        Console.WriteLine("Bang!");
                        bulletStack.Pop();
                        lockQueue.Dequeue();


                    }
                    else if (bulletStack.Peek() > lockQueue.Peek())
                    {
                        bulletStack.Pop();
                        Console.WriteLine("Ping!");

                    }
                }
                else
                {
                    if (bulletStack.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        magazineCounter = gunBarrelSize;
                    }

                }
            }
        }
    }
}
