using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());

            string[] header = Console.ReadLine()
                .Split(", ");

            string[,] matrix = new string[matrixDimensions - 1, header.Length];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] elementsOfMatrix = Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elementsOfMatrix[col];

                }
            }

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string currentCommand = command[0];
            string currentHeader = command[1];

            int indexOfHeaderElement = Array.IndexOf(header, currentHeader);
            if (currentCommand == "hide")
            {
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    matrix[rows, indexOfHeaderElement] = null;
                }
            }
            else if (currentCommand == "sort")
            {
                Array.Sort(matrix);
            }


            Console.WriteLine(string.Join(" | ", header.Where(x => x != currentHeader)));

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != null)
                    {
                        if (col == matrix.GetLength(1) - 1)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        else
                        {
                            Console.Write(matrix[row, col] + " | ");
                        }

                    }
                }
                Console.WriteLine();
            }
        }
    }
}
