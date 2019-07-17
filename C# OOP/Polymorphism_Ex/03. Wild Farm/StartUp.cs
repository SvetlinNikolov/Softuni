using _03._Wild_Farm.Models.Felines;
using _03._Wild_Farm.Models.Foods;
using System;

namespace _03._Wild_Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pussy = Console.ReadLine()
                .Split(" ");


            Cat cat = new Cat(pussy[1], double.Parse(pussy[2]), pussy[3], pussy[4]);
            Vegetable vegi = new Vegetable(1);

            try
            {
                cat.Feed(vegi);
            }
            catch (Exception ife)
            {

                Console.WriteLine(string.Format(ife.Message,cat.GetType().Name,vegi.GetType().Name));
            }
           
        }
    }
}
