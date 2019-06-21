using System;

namespace Day_2_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            double meal_cost = double.Parse(Console.ReadLine());

            double tip_percent = double.Parse(Console.ReadLine())/100;
           
            double tax_percent = double.Parse(Console.ReadLine())/100;
           
            double tip =  meal_cost * (tip_percent);

            double tax =  meal_cost * (tax_percent);

            double totalcost = Math.Round(tip + tax + meal_cost);

            Console.WriteLine(totalcost);
        }
    }
}
