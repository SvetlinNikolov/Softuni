using System;

namespace Day_10_Binary_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());

            string base2Number = Convert.ToString(n, 2);

            int maxOcurrenceOfOne = 0;

            int temp = 1;

            for (int i = 0; i < base2Number.Length - 1; i++)
            {
                
                if (base2Number[i] == base2Number[i + 1])
                {
                    temp++;
                }
                else
                {
                    if (temp >= maxOcurrenceOfOne)
                    {
                        maxOcurrenceOfOne = temp;
                        temp = 0;
                    }
                }
            }

            if (temp > maxOcurrenceOfOne)
            {
                Console.WriteLine(temp);
            }
            else
            {
                Console.WriteLine(maxOcurrenceOfOne);
            }
        }
    }
}
