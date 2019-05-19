using System;
using System.Linq;

namespace _04._Matrix_shuffling
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

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "END")
            {
                if (commands.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    commands = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                int row1;
                int col1;

                int row2;
                int col2;

                try
                {
                    row1 = int.Parse(commands[1]);
                    col1 = int.Parse(commands[2]);

                    row2 = int.Parse(commands[3]);
                    col2 = int.Parse(commands[4]);
                }
                catch
                {
                    Console.WriteLine("Invalid input!");

                    commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    continue;
                }


                if (row1 > matrix.GetLength(0)
                    || row1 < 0
                    || col1 > matrix.GetLength(1)
                    || col1 < 0
                    || row2 > matrix.GetLength(0)
                    || row2 < 0
                    || col2 > matrix.GetLength(1)
                    || col2 < 0)
                {
                    Console.WriteLine("Invalid input!");
                    commands = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                else
                {
                    int temp = 0;
                    temp = matrix[row1, col1];

                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                commands = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            }

        }
    }
}
