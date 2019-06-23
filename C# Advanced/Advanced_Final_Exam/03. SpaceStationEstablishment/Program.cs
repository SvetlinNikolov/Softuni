using System;
using System.Linq;

namespace _02.Task
{

    class StartUp
    {
        public static int starPower = 0;

        public static char[,] matrix = new char[0, 0];
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int spaceShipRow = 0;
            int spaceShipCol = 0;

            matrix = new char[sizeOfMatrix, sizeOfMatrix];

            bool foundBlackHole = false;

            int firstBlackHoleRow = 0;
            int firstBlackHoleCol = 0;

            int secondBlackHoleRow = 0;
            int secondBlackHoleCol = 0;

            for (int rows = 0; rows < sizeOfMatrix; rows++)
            {
                string elementsOfMatrix = Console.ReadLine();

                for (int cols = 0; cols < sizeOfMatrix; cols++)
                {
                    matrix[rows, cols] = elementsOfMatrix[cols];

                    if (matrix[rows, cols] == 'S')
                    {
                        spaceShipRow = rows;
                        spaceShipCol = cols;
                    }
                    else if (matrix[rows, cols] == 'O' && foundBlackHole == false)
                    {
                        foundBlackHole = true;

                        firstBlackHoleRow = rows;
                        firstBlackHoleCol = cols;
                    }
                    else if (matrix[rows, cols] == 'O' && foundBlackHole == true)
                    {
                        secondBlackHoleRow = rows;
                        secondBlackHoleCol = cols;
                    }
                }

            }
            //End of element insertion

            while (true)
            {

                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (IsInside(spaceShipRow - 1, spaceShipCol))
                    {
                        spaceShipRow--;

                        if (ThereIsNotBlackhole(spaceShipRow, spaceShipCol))
                        {
                            if (ThereIsStar(spaceShipRow, spaceShipCol))
                            {
                                double starValue = char.GetNumericValue(matrix[spaceShipRow, spaceShipCol]);
                                starPower += (int)(starValue);

                                matrix[spaceShipRow, spaceShipCol] = 'S';
                                matrix[spaceShipRow + 1, spaceShipCol] = '-';
                            }
                            else
                            {
                                matrix[spaceShipRow, spaceShipCol] = 'S';
                                matrix[spaceShipRow + 1, spaceShipCol] = '-';
                            }
                        }
                        else
                        {
                            if (spaceShipRow == firstBlackHoleRow
                                && spaceShipCol == firstBlackHoleCol)
                            {
                                matrix[spaceShipRow, spaceShipCol] = '-';
                                matrix[spaceShipRow + 1, spaceShipCol] = '-';

                                matrix[secondBlackHoleRow, secondBlackHoleCol] = 'S';
                                spaceShipRow = secondBlackHoleRow;
                                spaceShipCol = secondBlackHoleCol;
                            }
                            else if (spaceShipRow == secondBlackHoleRow
                                && spaceShipCol == secondBlackHoleCol)
                            {
                                matrix[spaceShipRow, spaceShipCol] = '-';
                                matrix[spaceShipRow + 1, spaceShipCol] = '-';

                                matrix[firstBlackHoleRow, firstBlackHoleCol] = 'S';

                                spaceShipRow = firstBlackHoleRow;
                                spaceShipCol = firstBlackHoleCol;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        matrix[spaceShipRow, spaceShipCol] = '-';
                        break;
                    }
                    //UP
                }





                else if (command == "down")
                {
                    if (IsInside(spaceShipRow + 1, spaceShipCol))
                    {
                        spaceShipRow++;

                        if (ThereIsNotBlackhole(spaceShipRow, spaceShipCol))
                        {
                            if (ThereIsStar(spaceShipRow, spaceShipCol))
                            {
                                double starValue = char.GetNumericValue(matrix[spaceShipRow, spaceShipCol]);
                                starPower += (int)(starValue);

                                matrix[spaceShipRow, spaceShipCol] = 'S';
                                matrix[spaceShipRow - 1, spaceShipCol] = '-';
                            }
                            else
                            {
                                matrix[spaceShipRow, spaceShipCol] = 'S';
                                matrix[spaceShipRow - 1, spaceShipCol] = '-';
                            }
                        }
                        else
                        {
                            if (spaceShipRow == firstBlackHoleRow
                                && spaceShipCol == firstBlackHoleCol)
                            {
                                //Here you put - row if down CORRECT LOGIC
                                matrix[spaceShipRow, spaceShipCol] = '-';
                                matrix[spaceShipRow - 1, spaceShipCol] = '-';


                                matrix[secondBlackHoleRow, secondBlackHoleCol] = 'S';
                                spaceShipRow = secondBlackHoleRow;
                                spaceShipCol = secondBlackHoleCol;
                            }
                            else if (spaceShipRow == secondBlackHoleRow
                                && spaceShipCol == secondBlackHoleCol)
                            {
                                //Here you put - row if down
                                matrix[spaceShipRow - 1, spaceShipCol] = '-';
                                matrix[spaceShipRow, spaceShipCol] = '-';

                                matrix[firstBlackHoleRow, firstBlackHoleCol] = 'S';

                                spaceShipRow = firstBlackHoleRow;
                                spaceShipCol = firstBlackHoleCol;
                            }
                        }

                    }
                    else
                    {
                        matrix[spaceShipRow, spaceShipCol] = '-';
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        break;
                    }
                }


                //Down^

                else if (command == "left")
                {
                    if (IsInside(spaceShipRow, spaceShipCol - 1))
                    {
                        spaceShipCol--;

                        if (ThereIsNotBlackhole(spaceShipRow, spaceShipCol))
                        {
                            if (ThereIsStar(spaceShipRow, spaceShipCol))
                            {
                                double starValue = char.GetNumericValue(matrix[spaceShipRow, spaceShipCol]);
                                starPower += (int)(starValue);

                                matrix[spaceShipRow, spaceShipCol] = 'S';
                                matrix[spaceShipRow, spaceShipCol + 1] = '-';
                            }
                            else
                            {
                                matrix[spaceShipRow, spaceShipCol] = 'S';
                                matrix[spaceShipRow, spaceShipCol + 1] = '-';
                            }
                        }
                        else
                        {
                            if (spaceShipRow == firstBlackHoleRow
                                && spaceShipCol == firstBlackHoleCol)
                            {
                                //Here you put - row if down CORRECT LOGIC
                                matrix[spaceShipRow, spaceShipCol] = '-';
                                matrix[spaceShipRow, spaceShipCol + 1] = '-';


                                matrix[secondBlackHoleRow, secondBlackHoleCol] = 'S';
                                spaceShipRow = secondBlackHoleRow;
                                spaceShipCol = secondBlackHoleCol;
                            }
                            else if (spaceShipRow == secondBlackHoleRow
                                && spaceShipCol == secondBlackHoleCol)
                            {
                                //Here you put - row if down
                                matrix[spaceShipRow, spaceShipCol + 1] = '-';
                                matrix[spaceShipRow, spaceShipCol] = '-';

                                matrix[firstBlackHoleRow, firstBlackHoleCol] = 'S';

                                spaceShipRow = firstBlackHoleRow;
                                spaceShipCol = firstBlackHoleCol;
                            }
                        }

                    }
                    else
                    {
                        matrix[spaceShipRow, spaceShipCol] = '-';
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        break;
                    }

                }
                //Left ^

                else if (command == "right")
                {
                    if (IsInside(spaceShipRow, spaceShipCol + 1))
                    {
                        spaceShipCol++;

                        if (ThereIsNotBlackhole(spaceShipRow, spaceShipCol))
                        {
                            if (ThereIsStar(spaceShipRow, spaceShipCol))
                            {
                                double starValue = char.GetNumericValue(matrix[spaceShipRow, spaceShipCol]);
                                starPower += (int)(starValue);

                                matrix[spaceShipRow, spaceShipCol] = 'S';
                                matrix[spaceShipRow, spaceShipCol - 1] = '-';
                            }
                            else
                            {
                                matrix[spaceShipRow, spaceShipCol] = 'S';
                                matrix[spaceShipRow, spaceShipCol - 1] = '-';
                            }
                        }
                        else
                        {
                            if (spaceShipRow == firstBlackHoleRow
                                && spaceShipCol == firstBlackHoleCol)
                            {
                                //Here you put - row if down CORRECT LOGIC
                                matrix[spaceShipRow, spaceShipCol] = '-';
                                matrix[spaceShipRow, spaceShipCol - 1] = '-';


                                matrix[secondBlackHoleRow, secondBlackHoleCol] = 'S';
                                spaceShipRow = secondBlackHoleRow;
                                spaceShipCol = secondBlackHoleCol;
                            }
                            else if (spaceShipRow == secondBlackHoleRow
                                && spaceShipCol == secondBlackHoleCol)
                            {
                                //Here you put - row if down
                                matrix[spaceShipRow, spaceShipCol - 1] = '-';
                                matrix[spaceShipRow, spaceShipCol] = '-';

                                matrix[firstBlackHoleRow, firstBlackHoleCol] = 'S';

                                spaceShipRow = firstBlackHoleRow;
                                spaceShipCol = firstBlackHoleCol;
                            }
                        }

                    }
                    else
                    {
                        matrix[spaceShipRow, spaceShipCol] = '-';
                        Console.WriteLine($"Bad news, the spaceship went to the void.");
                        break;
                    }

                }





                if (starPower >= 50)
                {
                    Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                    Console.WriteLine($"Star power collected: {starPower}");

                    for (int rows = 0; rows < matrix.GetLength(0); rows++)
                    {
                        for (int cols = 0; cols < matrix.GetLength(1); cols++)
                        {
                            Console.Write(matrix[rows, cols]);
                        }
                        Console.WriteLine();
                    }
                    return;
                }
            }
            //print matrix

            Console.WriteLine($"Star power collected: {starPower}");

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }

        private static bool ThereIsStar(int row, int col)
        {
            if (char.IsDigit(matrix[row, col]))
            {

                return true;
            }
            return false;
        }

        private static bool ThereIsNotBlackhole(int row, int col)
        {
            if (matrix[row, col] == 'O')
            {
                return false;
            }

            return true;
        }

        private static bool IsInside(int row, int col)
        {
            if (row < matrix.GetLength(0)
                && row >= 0
                && col < matrix.GetLength(1)
                && col >= 0)
            {
                return true;
            }
            return false;
        }
    }
}