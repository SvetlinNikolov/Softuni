using System;
using System.Linq;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsToSum = Console.ReadLine().Split().ToArray();

            string firstWord = wordsToSum[0];
            string secondWord = wordsToSum[1];

            string longerWord = string.Empty;
            string shorterWord = string.Empty;

            if (firstWord.Length >= secondWord.Length)
            {
                longerWord = firstWord;
                shorterWord = secondWord;
            }
            else
            {
                longerWord = secondWord;
                shorterWord = firstWord;
            }

            int sum = 0;

            for (int i = 0; i < shorterWord.Length; i++)
            {
                sum += shorterWord[i] * longerWord[i];
            }
            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                sum += longerWord[i];
            }
            Console.WriteLine(sum);

        }
    }
}
