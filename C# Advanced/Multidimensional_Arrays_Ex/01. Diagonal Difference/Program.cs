using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                int[] elementsOfMatrix = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = elementsOfMatrix[col];
                }
            }
            int sumOfPrimaryDiagonal = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                sumOfPrimaryDiagonal +=
                     matrix[row, row];
            }

            int sumOfSecondaryDiagonal = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    if (row + col == sizeOfMatrix - 1)
                    {
                        sumOfSecondaryDiagonal += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumOfPrimaryDiagonal-sumOfSecondaryDiagonal));
        }
    }
}
