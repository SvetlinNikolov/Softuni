using System;
using System.Linq;

namespace Miner
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            string[] directions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < size; row++)
            {
                char[] cols = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }          

            int[] currentPosition = new int[2];

            int coalCount = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        currentPosition[0] = row;
                        currentPosition[1] = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            int x = currentPosition[0];
            int y = currentPosition[1];

            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == "up")
                {
                    if (IsInside(matrix, x - 1, y))
                    {
                        if (matrix[x - 1, y] == 'e')
                        {
                            Console.WriteLine($"Game over! ({x - 1}, {y})");
                            return;
                        }
                        else if (matrix[x - 1, y] == 'c')
                        {
                            coalCount--;

                            if (coalCount == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({x - 1}, {y})");
                                return;
                            }

                            matrix[x - 1, y] = '*';
                        }

                        x -= 1;
                    }
                }
                else if (directions[i] == "down")
                {
                    if (IsInside(matrix, x + 1, y))
                    {
                        if (matrix[x + 1, y] == 'e')
                        {
                            Console.WriteLine($"Game over! ({x + 1}, {y})");
                            return;
                        }
                        else if (matrix[x + 1, y] == 'c')
                        {
                            coalCount--;

                            if (coalCount == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({x + 1}, {y})");
                                return;
                            }

                            matrix[x + 1, y] = '*';
                        }

                        x += 1;
                    }
                }
                else if (directions[i] == "right")
                {
                    if (IsInside(matrix, x, y + 1))
                    {
                        if (matrix[x, y + 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({x}, {y + 1})");
                            return;
                        }
                        else if (matrix[x, y + 1] == 'c')
                        {
                            coalCount--;

                            if (coalCount == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({x}, {y + 1})");
                                return;
                            }

                            matrix[x, y + 1] = '*';
                        }
                       
                        y += 1;
                    }
                }
                else if (directions[i] == "left")
                {
                    if (IsInside(matrix, x, y - 1))
                    {
                        if (matrix[x, y - 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({x}, {y - 1})");
                            return;
                        }
                        else if (matrix[x, y - 1] == 'c')
                        {
                            coalCount--;

                            if (coalCount == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({x}, {y - 1})");
                                return;
                            }

                            matrix[x, y - 1] = '*';
                        }

                        y -= 1;
                    }
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({x}, {y})");
        }
        private static bool IsInside(char[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0 &&
                desiredCol < board.GetLength(1) && desiredCol >= 0;
        }
    }
}