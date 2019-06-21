using System;

namespace Day_3_Conditional_Statements
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number >= 2 && number <= 5 && number % 2 == 0)
            {
                Console.WriteLine("Not Weird");
            }
            else if ((number >= 6 && number <= 20 && number % 2 == 0))
            {
                Console.WriteLine("Weird");
            }
            else if (number >= 20 && number % 2 == 0)
            {
                Console.WriteLine("Not Weird");
            }
            else
            {
                Console.WriteLine("Weird");
            }
        }
    }
}
