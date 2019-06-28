using System;

namespace _01.Rhombus_of_Stars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rhombusSize = int.Parse(Console.ReadLine());

            PrintRow(rhombusSize);

        }

        private static void PrintRow(int rhombusSize)
        {
            for (int i = 1; i <= rhombusSize; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            for (int i = 1; i <= rhombusSize; i++)
            {
                for (int j = rhombusSize - 1; j >= i; j--)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
