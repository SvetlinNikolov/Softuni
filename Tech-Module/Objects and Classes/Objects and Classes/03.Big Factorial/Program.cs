using System;
using System.Numerics;

namespace _03.Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger calcFac = 1;

            for (int i = 1; i <= input; i++)
            {
                calcFac *= i;
            }
            Console.WriteLine(calcFac);
        }
    }
}
