using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Task
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] liquids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] physicalItems = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> queueLiquids = new Queue<int>(liquids);
            Stack<int> stackPhysicalItems = new Stack<int>(physicalItems);

            int glassCount = 0;
            int aluminiumCount = 0;
            int lithiumCount = 0;
            int carbonFiberCount = 0;


            while (true)
            {
                if (queueLiquids.Count == 0 || stackPhysicalItems.Count == 0)
                {
                    break;
                }

                int currentLiquid = queueLiquids.Dequeue();
                int currentPhysicalItem = stackPhysicalItems.Pop();

                int sumOfItems = currentLiquid + currentPhysicalItem;

                if (sumOfItems == 25)
                {
                    glassCount++;
                }
                else if (sumOfItems == 50)
                {
                    aluminiumCount++;
                }
                else if (sumOfItems == 75)
                {
                    lithiumCount++;
                }
                else if (sumOfItems == 100)
                {
                    carbonFiberCount++;
                }
                else
                {
                    stackPhysicalItems.Push(currentPhysicalItem + 3);
                }

            }

            if (glassCount > 0 && aluminiumCount > 0 && lithiumCount > 0 && carbonFiberCount > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (queueLiquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queueLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stackPhysicalItems.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", stackPhysicalItems)}");
            }
            else
            {
                Console.WriteLine($"Physical items left: none");
            }


            Console.WriteLine($"Aluminium: {aluminiumCount}");
            Console.WriteLine($"Carbon fiber: {carbonFiberCount}");
            Console.WriteLine($"Glass: {glassCount}");
            Console.WriteLine($"Lithium: {lithiumCount}");


        }

    }
}