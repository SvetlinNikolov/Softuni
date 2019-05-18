using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
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

            int[,] matrix = new int[matrixRows, matrixCols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                int[] matrixElements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();


                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    matrix[row, col] = matrixElements[col];
                }
               
            }
            //here ends elements insertion
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum );
                sum = 0;
            }
        }
    }
}
