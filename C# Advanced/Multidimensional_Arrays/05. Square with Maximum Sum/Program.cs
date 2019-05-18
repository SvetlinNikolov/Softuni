using System;
using System.Linq;

namespace _05._Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowAndColSize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowAndColSize[col];
                }
            }
            //here ends item insertion in matrix

            int biggestSum = int.MinValue;

            int upperLeft = 0;
            int upperRight = 0;
            int lowerLeft = 0;
            int lowerRight = 0;

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row + 1, col]
                        + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        upperLeft = matrix[row, col];
                        upperRight = matrix[row, col + 1];
                        lowerLeft = matrix[row + 1, col];
                        lowerRight = matrix[row + 1, col + 1];
                    }

                }
            }
            Console.WriteLine($"{upperLeft} {upperRight}\n" +
                $"{lowerLeft} {lowerRight}\n" +
                $"{biggestSum}");
        }
    }
}
