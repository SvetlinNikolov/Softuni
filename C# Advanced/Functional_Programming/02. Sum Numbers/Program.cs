using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);

            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToArray();

            Console.WriteLine(FindCount(numbers));
            Console.WriteLine(FindSum(numbers));



        }
        public static int FindSum(int[] array)
        {
            return array.Sum();
        }
        public static int FindCount(int[] array)
        {
            return array.Count();
        }
    }

}