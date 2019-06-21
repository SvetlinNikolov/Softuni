using System;
using System.Linq;

namespace _02._Helen_s_Abduction
{
    class StartUp
    {
        public static char[][] matrix = new char[0][];
        static void Main(string[] args)
        {

            int energy = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            matrix = new char[rows][];

            int parisRow = 0;
            int parisCol = 0;

            bool won = false;

            for (int row = 0; row < rows; row++)
            {
                string elementsOfArray = Console.ReadLine();

                matrix[row] = new char[elementsOfArray.Length];

                for (int col = 0; col < elementsOfArray.Length; col++)
                {

                    matrix[row][col] = elementsOfArray[col];

                    if (matrix[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }
            //End of Element Insertion

            while (energy > 0)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = commands[0];

                int enemyRow = int.Parse(commands[1]);
                int enemyCol = int.Parse(commands[2]);

                matrix[enemyRow][enemyCol] = 'S';

                energy--;

                if (direction == "up")
                {
                    if (IsInside(parisRow - 1, parisCol))
                    {
                        parisRow--;

                        if (SpartanIsThere(parisRow, parisCol))
                        {
                            matrix[parisRow + 1][parisCol] = '-';
                            matrix[parisRow][parisCol] = 'P';

                            energy -= 2;
                        }
                        else if (HelenIsThere(parisRow, parisCol))
                        {
                            matrix[parisRow][parisCol] = '-';
                            matrix[parisRow + 1][parisCol] = '-';

                            won = true;
                            break;
                        }
                        else
                        {
                            matrix[parisRow + 1][parisCol] = '-';
                            matrix[parisRow][parisCol] = 'P';
                        }
                    }
                }

                else if (direction == "down")
                {
                    if (IsInside(parisRow + 1, parisCol))
                    {
                        parisRow++;

                        if (SpartanIsThere(parisRow, parisCol))
                        {
                            matrix[parisRow - 1][parisCol] = '-';
                            matrix[parisRow][parisCol] = 'P';
                            energy -= 2;
                        }
                        else if (HelenIsThere(parisRow, parisCol))
                        {
                            matrix[parisRow][parisCol] = '-';
                            matrix[parisRow - 1][parisCol] = '-';

                            won = true;
                            break;
                        }
                        else
                        {
                            matrix[parisRow - 1][parisCol] = '-';
                            matrix[parisRow][parisCol] = 'P';
                        }
                    }
                }

                else if (direction == "left")
                {
                    if (IsInside(parisRow, parisCol - 1))
                    {
                        parisCol--;
                        if (SpartanIsThere(parisRow, parisCol))
                        {
                            matrix[parisRow][parisCol + 1] = '-';
                            matrix[parisRow][parisCol] = 'P';

                            energy -= 2;
                        }
                        else if (HelenIsThere(parisRow, parisCol))
                        {
                            matrix[parisRow][parisCol] = '-';
                            matrix[parisRow][parisCol + 1] = '-';

                            won = true;
                            break;
                        }
                        else
                        {
                            matrix[parisRow][parisCol + 1] = '-';
                            matrix[parisRow][parisCol] = 'P';
                        }
                    }
                }

                else if (direction == "right")
                {
                    if (IsInside(parisRow, parisCol + 1))
                    {
                        parisCol++;
                        if (SpartanIsThere(parisRow, parisCol))
                        {
                            matrix[parisRow][parisCol - 1] = '-';
                            matrix[parisRow][parisCol] = 'P';
                            energy -= 2;
                        }
                        else if (HelenIsThere(parisRow, parisCol))
                        {
                            matrix[parisRow][parisCol] = '-';
                            matrix[parisRow][parisCol - 1] = '-';

                            won = true;
                            break;
                        }
                        else
                        {
                            matrix[parisRow][parisCol - 1] = '-';
                            matrix[parisRow][parisCol] = 'P';
                        }
                    }
                }

            }

            if (won)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }
            else
            {
                matrix[parisRow][parisCol] = 'X';

                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
        private static bool SpartanIsThere(int spartanRow, int spartanCol)
        {
            if (matrix[spartanRow][spartanCol] == 'S')
            {
                return true;
            }
            return false;
        }
        private static bool HelenIsThere(int helenRow, int helenCol)
        {
            if (matrix[helenRow][helenCol] == 'H')
            {
                return true;
            }
            return false;
        }
        public static bool IsInside(int currentRow, int currentCol)
        {
            if (currentRow < matrix.GetLength(0)
                      && currentRow >= 0
                      && currentCol < matrix[currentRow].Length
                      && currentCol >= 0)
            {
                return true;
            }
            return false;
        }

    }
}
