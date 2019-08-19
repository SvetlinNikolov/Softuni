using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Remove_Odd_Occurrences
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> collectionOfNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int countOccurences = 0;

            for (int i = 0; i < collectionOfNums.Count; i++)
            {
                for (int j = i+1; j < collectionOfNums.Count; j++)
                {
                    if (collectionOfNums[i] == collectionOfNums[j])
                    {
                        countOccurences++;
                    }
                   
                }
                if (countOccurences % 2 == 0)
                {
                    int numberToRemove = collectionOfNums[i];
                    collectionOfNums.RemoveAll(x => x == numberToRemove);
                    
                }
                countOccurences = 0;
             
            }
            Console.WriteLine(string.Join(" ",collectionOfNums));
        }
    }
}