using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                int[] elementsOfMatrix = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    squareMatrix[row, col] = elementsOfMatrix[col];
                }
            }

            int sumOfPrimaryDiagonal = 0;


            for (int row = 0; row < sizeOfMatrix; row++)
            {

                sumOfPrimaryDiagonal += squareMatrix[row, row];
            }
            Console.WriteLine(sumOfPrimaryDiagonal);
        }

    }
}


