using System;
using System.Linq;
using System.Collections.Generic;


namespace _06._Bomb_the_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            int[] bombsInformation = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int bombRow = bombsInformation[0];
            int bombCol = bombsInformation[1];
            int bombRadius = bombsInformation[0];

            Console.WriteLine("Yeet");

        }
    }
}
