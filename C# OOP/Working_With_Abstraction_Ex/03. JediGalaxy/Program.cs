using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Program
    {
        public static void Main()
        {
            int[] dimestionsOfMatrix = Console.ReadLine()
                .Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = CreateMatrix(dimestionsOfMatrix);

            FillMatrix(matrix);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Let the Force be with you")
                {
                    break;
                }

                int[] ivoCoordinates = command
                    .Split(new string[] { " " }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                int ivoRow = ivoCoordinates[0];
                int ivoCol = ivoCoordinates[1];

                EvilTraverseDiagonal(matrix, ref evilRow, ref evilCol);

                int ivoCollectedStarts = IvoTraverseDiagonal(ivoRow, ivoCol, matrix);

                Console.WriteLine(ivoCollectedStarts);
            }

           

        }

        private static void EvilTraverseDiagonal(int[,] matrix, ref int evilRow, ref int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0
                    && evilRow < matrix.GetLength(0)
                    && evilCol >= 0
                    && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        public static int IvoTraverseDiagonal(int row,int col,int [,] matrix)
        {
            int sumOfIvoCollectedStars = 0;

            while (row >= 0 && col < matrix.GetLength(1))
            {
                if (row >= 0
                    && row < matrix.GetLength(0)
                    && col >= 0
                    && col < matrix.GetLength(1))
                {

                    sumOfIvoCollectedStars += matrix[row, col];
                   
                }

                col++;
                row--;
            }
            return sumOfIvoCollectedStars;
        }


        public static void FillMatrix(int[,] matrix)
        {
            int matrixFill = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixFill++;
                }
            }
        }
        public static int[,] CreateMatrix(int[] dimensions)
        {

            int matrixRows = dimensions[0];
            int matrixCols = dimensions[1];

            int[,] matrix = new int[matrixRows, matrixCols];
            return matrix;
        }
    }
}
