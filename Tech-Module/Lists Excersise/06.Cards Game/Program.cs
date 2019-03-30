using System;
using System.Linq;
using System.Collections.Generic;
namespace _06.Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var secondDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            LargerOfTwoDecks(firstDeck, secondDeck);

        }

        private static void LargerOfTwoDecks(List<int> firstDeck, List<int> secondDeck)
        {
            int sum = 0;

            for (int i = 0; i < Math.Min(firstDeck.Count, secondDeck.Count); i++)
            {

                if (firstDeck[i] == secondDeck[i])
                {
                    firstDeck.Remove(firstDeck[i]);
                    secondDeck.Remove(secondDeck[i]);
                }
                else if (firstDeck[i] > secondDeck[i])
                {
                    int biggerCard = firstDeck[i];
                    int smallerCard = secondDeck[i];

                    secondDeck.Remove(secondDeck[i]);
                    firstDeck.Remove(firstDeck[i]);

                    firstDeck.Add(biggerCard);
                    firstDeck.Add(smallerCard);
                }
                else if (firstDeck[i] < secondDeck[i])
                {

                    int biggerCard = secondDeck[i];
                    int smallerCard = firstDeck[i];

                    firstDeck.Remove(firstDeck[i]);
                    secondDeck.Remove(secondDeck[i]);

                    secondDeck.Add(biggerCard);
                    secondDeck.Add(smallerCard);

                }
                i = -1;
            }
            if (firstDeck.Count > secondDeck.Count)
            {
                foreach (var element in firstDeck)
                {
                    sum += element;
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if (firstDeck.Count < secondDeck.Count)
            {
                foreach (var element in secondDeck)
                {
                    sum += element;
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}