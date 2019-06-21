using System;
using System.Linq;

namespace Day_14_Scope
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Difference d = new Difference(input);

            d.computeDifference();
            Console.WriteLine(d.maximumDifference);
        }
    }

    class Difference
    {
        public int[] elements;
        public int maximumDifference;

        public Difference(int[] arr)
        {
            elements = arr;
        }

        public void computeDifference()
        {
            maximumDifference = int.MinValue;

            for (int i = 0; i < elements.Length - 1; i++)
            {
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    int temp = Math.Abs(elements[i] - elements[j + 1]);

                    if (temp > maximumDifference)
                    {
                        maximumDifference = temp;
                    }
                }

            }
        }
    }
}