
namespace _03._Custom_Min_Function
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Func<int[], int> smallestNum = x =>
             {
                 int minValue = int.MaxValue;
                 foreach (var item in x)
                 {
                     if (item < minValue)
                     {
                         minValue = item;
                     }
                 }
                 return minValue;
             };

            int smallestNumber = smallestNum(numbers);
            Console.WriteLine(smallestNumber);

        }
    }
}
