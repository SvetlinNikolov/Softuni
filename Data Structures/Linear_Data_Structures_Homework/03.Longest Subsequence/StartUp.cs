using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Longest_Subsequence
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> currentLongestSequence = new List<int>();
            List<int> tempSequence = new List<int>();

            if (numbers.Count == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }
            for (int i = 0; i < numbers.Count - 1; i++)
            {

                while (i != numbers.Count - 1)
                {
                   
                    if (numbers[i] == numbers[i + 1])
                    {
                        tempSequence.Add(numbers[i]);
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (tempSequence.Count > currentLongestSequence.Count)
                {
                    {
                        currentLongestSequence = tempSequence.ToList();
                        tempSequence.Clear();
                    }
                }

            }
            //This is my non mathematical solution to the task
            
            if (currentLongestSequence.Count == 0)
            {
                Console.WriteLine(numbers[0]);
            }
            else
            {
                Console.WriteLine(string.Join(" ", currentLongestSequence) + " " + currentLongestSequence[0]);
            }

        }
    }
}
