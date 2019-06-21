using System;

namespace Day_1_Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 4;
            double d = 4.0;
            string s = "HackerRank ";

            int integerToSum = int.Parse(Console.ReadLine());

            double doubleToSum = double.Parse(Console.ReadLine());

            string textToConcat = Console.ReadLine();

            Console.WriteLine(i + integerToSum);
            Console.WriteLine(d + doubleToSum);
            Console.WriteLine(s + textToConcat);
        }
    }
}
