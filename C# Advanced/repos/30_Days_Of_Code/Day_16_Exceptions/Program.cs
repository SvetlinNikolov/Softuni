using System;

namespace Day_16_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                int.Parse(input);
                Console.WriteLine(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad String");
            }
        }
    }
}