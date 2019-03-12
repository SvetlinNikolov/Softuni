using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string codeMessage = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<string> nonNumbers = new List<string>();

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            List<string> endResult = new List<string>();

            foreach (var number in codeMessage)
            {
                if (char.IsDigit(number))
                {
                    numbers.Add(int.Parse(number.ToString()));
                }
                else
                {
                    nonNumbers.Add(number.ToString());
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }
            for (int i = 0; i < takeList.Count; i++)
            {
                for (int j = i; j <= takeList[i]; j++)
                {
                    endResult.Add(nonNumbers[j]);

                    for (int k = 0; k < skipList.Count; k++)
                    {
                        for (int l = k; l <= skipList[k]; l++)
                        {
                            endResult.Add(nonNumbers[l]);
                        }
                    }
                }
            }
        }
    }
}
