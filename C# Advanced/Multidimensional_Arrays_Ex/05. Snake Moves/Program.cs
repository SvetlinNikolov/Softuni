using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionsOfMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensionsOfMatrix[0];
            int cols = dimensionsOfMatrix[1];

            string snake = Console.ReadLine();

            char[] snakeArray = new char[snake.Length];

            int indexInSnake = 0;

            for (int i = 0; i < snake.Length; i++)
            {
                snakeArray[i] = snake[i];
            }

            char[,] trailOfSnake = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (indexInSnake == snakeArray.Length)
                    {
                        indexInSnake = 0;
                    }
                    trailOfSnake[row, col] = snakeArray[indexInSnake];
                    Console.Write(trailOfSnake[row, col]);
                    indexInSnake++;
                }
                Console.WriteLine();
            }
        }
    }
}
