
namespace _12._Cups_And_Bottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottles = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> cupsCapacity = new Queue<int>(cups);
            Stack<int> bottleCapacity = new Stack<int>(bottles);

            int wastedWater = 0;

            while (true)
            {
                if (cupsCapacity.Count == 0)
                {
                    break;
                    //izpisvame butilki i wasted water
                }

                if (bottleCapacity.Count == 0)
                {
                    break;
                }

                int currentBottle = bottleCapacity.Peek();
                int currentCup = cupsCapacity.Peek();

                if (currentBottle - currentCup >= 0)
                {
                    wastedWater += Math.Abs(currentBottle - currentCup);

                    cupsCapacity.Dequeue();
                    bottleCapacity.Pop();
                }
                else if (currentBottle-currentCup < 0)
                {
                    int largerCup = currentCup - currentBottle;

                    bottleCapacity.Pop();

                    if (bottleCapacity.Count == 0)
                    {
                        break;
                    }
                    if (bottleCapacity.Peek() - largerCup < 0 && bottleCapacity.Count != 0)
                    {
                        largerCup = largerCup - bottleCapacity.Pop();

                        if (largerCup < 0)
                        {
                            wastedWater += Math.Abs(largerCup);
                            break;
                        }
                    }
                    else
                    {
                        largerCup = largerCup - bottleCapacity.Pop();

                        if (largerCup < 0)
                        {
                            wastedWater += Math.Abs(largerCup);
                         
                        }
                    }
                }

            }
            Console.WriteLine();
        }

    }
}

