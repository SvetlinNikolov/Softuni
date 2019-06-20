using System;

namespace _02._Tron_Racers1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];

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
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                    else if (elementsOfMatrix[col] == 's')
                    {
                       
                    }
                }
            }
            // End of element insertion

            while (true)
            {
                string[] playerCommands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string secondPlayerCommand = playerCommands[0];
               

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



                // *****************************************





                for (int i = 0; i < sizeOfMatrix; i++)
                {

                    for (int j = 0; j < sizeOfMatrix; j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
