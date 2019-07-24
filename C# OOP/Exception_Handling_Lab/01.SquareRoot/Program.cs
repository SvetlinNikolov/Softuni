using System;

namespace _01.SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine(Math.Sqrt(a));
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Invalid number",ex);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }    
        }
    }
}
