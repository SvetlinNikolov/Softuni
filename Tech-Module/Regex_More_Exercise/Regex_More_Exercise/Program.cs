using System;
using System.Text.RegularExpressions;
namespace Regex_More_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            string namePattern = @"(?<=@)([A-z]+)\|";
            Regex nameRegex = new Regex(namePattern);

            string yearsPattern = @"(?<=#)([0-9]+)\*";
            Regex yearsRegex = new Regex(yearsPattern);

            for (int i = 0; i < numberOfMessages; i++)
            {
                string message = Console.ReadLine();

                Match nameMatch = nameRegex.Match(message);
                Match yearsMatch = yearsRegex.Match(message);

                if (nameMatch.Success&& yearsMatch.Success)
                {
                    Console.WriteLine($"{nameMatch.Groups[1].Value} is {yearsMatch.Groups[1].Value} years old.");
                }

            }
        }
    }
}
