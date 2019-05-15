using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int rackCapacity = int.Parse(Console.ReadLine());

            int originalRackCapacity = rackCapacity;

            int numberOfRacksUsed = 1;

            while (stack.Count > 0)
            {
                if (rackCapacity - stack.Peek() > 0)
                {
                    rackCapacity -= stack.Pop();
                }
                else if (rackCapacity - stack.Peek() == 0)
                {
                        numberOfRacksUsed++;
                        rackCapacity = originalRackCapacity;
                        stack.Pop();
                }
                else if (rackCapacity - stack.Peek() < 0)
                {
                    numberOfRacksUsed++;

                    rackCapacity = originalRackCapacity;
                    rackCapacity -= stack.Pop();

                }
            }
            Console.WriteLine(numberOfRacksUsed);
        }
    }
}
