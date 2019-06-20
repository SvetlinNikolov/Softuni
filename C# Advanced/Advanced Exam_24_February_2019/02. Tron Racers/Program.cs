using System;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];

            int firstPlayerRow = 0;
            int firstPlayerCol = 0;
            int secondPlayerRow = 0;
            int secondPlayerCol = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                string elementsOfMatrix = Console.ReadLine();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = elementsOfMatrix[col];

                    if (elementsOfMatrix[col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (elementsOfMatrix[col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
            // End of element insertion

            while (true)
            {
                string[] playerCommands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstPlayerCommand = playerCommands[0];
                string secondPlayerCommand = playerCommands[1];

                if (firstPlayerCommand == "up")
                {
                    firstPlayerRow -= 1;

                    if (firstPlayerRow > 0 && matrix[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'x';
                        break;
                    }

                    if (firstPlayerRow < 0)
                    {
                        if (matrix[matrix.GetLength(0) - 1, firstPlayerCol] == 's')
                        {
                            matrix[matrix.GetLength(0) - 1, firstPlayerCol] = 'x';
                            break;
                        }
                        matrix[matrix.GetLength(0) - 1, firstPlayerCol] = 'f';

                        firstPlayerRow = matrix.GetLength(0) - 1;

                    }
                    matrix[firstPlayerRow, firstPlayerCol] = 'f';
                }


                if (firstPlayerCommand == "down")
                {
                    firstPlayerRow += 1;

                    if (firstPlayerRow >= matrix.GetLength(0) && matrix[0, firstPlayerCol] == 's')
                    {
                        matrix[0, firstPlayerCol] = 'x';
                        break;

                    }
                    else if (firstPlayerRow > matrix.GetLength(0) && matrix[0, firstPlayerCol] != 's')
                    {
                        matrix[0, firstPlayerCol] = 'f';
                    }

                    if (firstPlayerRow < matrix.GetLength(0))
                    {
                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }

                    }

                }
                if (firstPlayerCommand == "left")
                {
                    firstPlayerCol -= 1;

                    if (firstPlayerCol > 0 && matrix[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'x';
                        break;
                    }

                    if (firstPlayerCol < 0)
                    {
                        if (matrix[firstPlayerRow, matrix.GetLength(1) - 1] == 's')
                        {
                            matrix[firstPlayerRow, matrix.GetLength(1) - 1] = 'x';
                            break;
                        }
                        matrix[firstPlayerRow, matrix.GetLength(1) - 1] = 'f';

                        firstPlayerCol = matrix.GetLength(1) - 1;

                    }
                    matrix[firstPlayerRow, firstPlayerCol] = 'f';
                }


                if (firstPlayerCommand == "right")
                {
                    firstPlayerCol += 1;

                    if (firstPlayerCol >= matrix.GetLength(1) && matrix[firstPlayerRow, 0] == 's')
                    {
                        matrix[firstPlayerRow, 0] = 'x';
                        break;
                    }
                    else if (firstPlayerCol >= matrix.GetLength(1) && matrix[firstPlayerRow, 0] != 's')
                    {
                        matrix[firstPlayerRow, 0] = 'f';
                    }

                    if (firstPlayerCol < matrix.GetLength(1))
                    {
                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }

                    }
                    matrix[firstPlayerRow, firstPlayerCol] = 'f';
                }



                // *****************************************

                if (secondPlayerCommand == "up")
                {
                    secondPlayerRow -= 1;

                    if (secondPlayerRow > 0 && matrix[secondPlayerRow, secondPlayerCol] == 'f')
                    {
                        matrix[secondPlayerRow, secondPlayerCol] = 'x';
                        break;
                    }

                    if (secondPlayerRow < 0)
                    {
                        if (matrix[matrix.GetLength(0) - 1, secondPlayerCol] == 'f')
                        {
                            matrix[matrix.GetLength(0) - 1, secondPlayerCol] = 'x';
                            break;
                        }
                        matrix[matrix.GetLength(0) - 1, secondPlayerCol] = 's';

                        secondPlayerRow = matrix.GetLength(0) - 1;

                    }
                    matrix[secondPlayerRow, secondPlayerCol] = 's';
                }


                if (secondPlayerCommand == "down")
                {
                    secondPlayerRow += 1;

                    if (secondPlayerRow >= matrix.GetLength(0) && matrix[0, secondPlayerCol] == 'f')
                    {
                        matrix[0, secondPlayerCol] = 'x';
                        break;

                    }
                    else if (secondPlayerRow > matrix.GetLength(0) && matrix[0, secondPlayerCol] != 'f')
                    {
                        matrix[0, secondPlayerCol] = 's';
                    }

                    if (secondPlayerRow < matrix.GetLength(0))
                    {
                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }

                    }

                }
                if (secondPlayerCommand == "left")
                {
                    secondPlayerCol -= 1;

                    if (secondPlayerCol > 0 && matrix[secondPlayerRow, secondPlayerCol] == 'f')
                    {
                        matrix[secondPlayerRow, secondPlayerCol] = 'x';
                        break;
                    }

                    if (secondPlayerCol < 0)
                    {
                        if (matrix[secondPlayerRow, matrix.GetLength(1) - 1] == 'f')
                        {
                            matrix[secondPlayerRow, matrix.GetLength(1) - 1] = 'x';
                            break;
                        }
                        matrix[secondPlayerRow, matrix.GetLength(1) - 1] = 's';

                        secondPlayerCol = matrix.GetLength(1) - 1;

                    }
                    matrix[secondPlayerRow, secondPlayerCol] = 's';
                }


                if (secondPlayerCommand == "right")
                {
                    secondPlayerCol += 1;

                    if (secondPlayerCol >= matrix.GetLength(1) && matrix[secondPlayerRow, 0] == 'f')
                    {
                        matrix[secondPlayerRow, 0] = 'x';
                        break;
                    }
                    else if (secondPlayerCol >= matrix.GetLength(1) && matrix[secondPlayerRow, 0] != 'f')
                    {
                        matrix[secondPlayerRow, 0] = 's';
                    }

                    if (secondPlayerCol < matrix.GetLength(1))
                    {
                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }

                    }
                    matrix[secondPlayerRow, secondPlayerCol] = 's';
                }
               
            }
            for (int i = 0; i < sizeOfMatrix; i++)
            {

                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
