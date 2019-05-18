using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int matrixRows = rowsAndCols[0];
            int matrixCols = rowsAndCols[1];

            Console.WriteLine(matrixRows);
            Console.WriteLine(matrixCols);

            int[,] matrix = new int[matrixRows, matrixCols];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] matrixElements = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = matrixElements[cols];
                }
            }

            int sum = 0;


            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }
    }
}
