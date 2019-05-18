using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] symbolMatrix = new char[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                string symbolsToAdd = Console.ReadLine();


                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    symbolMatrix[row, col] = symbolsToAdd[col];
                }
            }
            char characterToFind = char.Parse(Console.ReadLine());

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    if (symbolMatrix[row,col]== characterToFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{characterToFind} does not occur in the matrix");
        }
    }
}
