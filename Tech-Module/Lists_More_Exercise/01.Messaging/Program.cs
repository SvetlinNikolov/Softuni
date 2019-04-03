using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()

                .Select(int.Parse)
                .ToList();

            List<int> listOfInts = new List<int>();

            string message = Console.ReadLine();
            string resultString = string.Empty;
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                while (numbers[i] > 0)
                {
                    int temp = numbers[i] % 10;
                    sum += temp;
                    numbers[i] /= 10;
                }
                for (int j = 0; j < message.Length; j++)
                {
                    while (message.Length<sum)
                    {
                        sum = sum - message.Length;
                    }
                    
                    message.Remove(sum);
                }

                sum = 0;
            }
        }
    }
}
