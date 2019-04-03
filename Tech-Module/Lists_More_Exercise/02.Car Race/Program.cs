using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            double leftSide = 0;
            double rightSide = 0;

            for (int i = 0; i <arrayOfNumbers.Length/2; i++)
            {
                if (arrayOfNumbers[i] != 0)
                {
                    leftSide += arrayOfNumbers[i];
                }
                if (arrayOfNumbers[i]==0)
                {
                    leftSide -= leftSide * 0.2;
                }
                
                
            }
            for (int j = arrayOfNumbers.Length - 1; j > arrayOfNumbers.Length / 2+1; j--)
            {
                if (arrayOfNumbers[j] != 0)
                {
                    rightSide += arrayOfNumbers[j];
                }
                if (arrayOfNumbers[j] == 0)
                {
                    rightSide -= rightSide * 0.2;
                }
               
            }
            if (leftSide > rightSide)
            {
                Console.WriteLine($"The winner is left with total time: {rightSide}");
            }
           if (rightSide>leftSide)
            {
                Console.WriteLine($"The winner is left with total time: {leftSide}");
            }
            
        }
    }
}
