
namespace _02._Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] countNumbersInSets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstSet = countNumbersInSets[0];
            int secondSet = countNumbersInSets[1];

            HashSet<int> firstHash = new HashSet<int>();
            HashSet<int> secondHash = new HashSet<int>();

            for (int i = 0; i < firstSet; i++)
            {
                int numberToAdd = int.Parse(Console.ReadLine());

                firstHash.Add(numberToAdd);

            }
            for (int j = 0; j < secondSet; j++)
            {
                int numberToAdd = int.Parse(Console.ReadLine());

                secondHash.Add(numberToAdd);
            }

            foreach (var element in firstHash)
            {
                if (secondHash.Contains(element))
                {
                    Console.Write(element +" ");
                }
            }
        }
    }
}
