using System;
using System.Linq;

namespace _03._Maximal_Sum
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

            for (int row = 0; row < rows; row++)
            {
                int[] elementsOfMatrix = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elementsOfMatrix[col];
                }
            }

            int largestSum = 0;
            int[,] largestMatrix = new int[3, 3];

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int tempSum = matrix[row, col] + matrix[row + 1, col]
                       + matrix[row, col + 1] + matrix[row + 1, col + 1]
                       + matrix[row + 2, col] + matrix[row + 2, col + 1]
                       + matrix[row + 2, col + 2] + matrix[row, col + 2]
                       + matrix[row + 1, col + 2];

                    if (tempSum > largestSum)
                    {
                        largestSum = tempSum;

                        largestMatrix = new int[,] {
                        {  matrix[row, col], matrix[row, col + 1],matrix[row, col + 2]},
                        {matrix[row + 1, col],matrix[row + 1, col + 1] ,matrix[row + 1, col + 2]},
                        {matrix[row + 2, col], matrix[row + 2, col + 1], matrix[row + 2, col + 2]}
                        };
                    }
                }
            }
            Console.WriteLine($"Sum = {largestSum}");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(largestMatrix[row,col]+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
