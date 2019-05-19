using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[numberOfRows][];

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                int[] elementsOfArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < elementsOfArray.Length; col++)
                {
                    jaggedArray[row] = elementsOfArray;
                }
            }

            //here ends insertion of elements

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "END")
            {
                string currentCommand = command[0];

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (currentCommand == "Add")
                {

                    if (row > jaggedArray.Length
                        || row < 0
                        || col > jaggedArray.Length
                        || col < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        jaggedArray[row][col] += value;
                    }
                }
                else if (currentCommand == "Subtract")
                {
                    if (row > jaggedArray.Length
                        || row < 0
                        || col > jaggedArray.Length
                        || col < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} " );
                }
                Console.WriteLine();
            }
        }
    }
}
