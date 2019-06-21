using System;
using System.Linq;

namespace Day_11_2D_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            int sum = int.MinValue;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int tempSum = matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2]
                        + matrix[i + 1][j + 1]
                        + matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}