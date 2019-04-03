using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGuests = int.Parse(Console.ReadLine());
            List<string> guestsOfParty = new List<string>();
            List<string> peopleGointForSure = new List<string>();
            List<string> result = new List<string>();

            for (int i = 0; i < numberOfGuests; i++)
            { 
                guestsOfParty = Console.ReadLine().Split().ToList();
                if ((guestsOfParty.Count == 3 && peopleGointForSure.Contains(guestsOfParty[0])))
                {
                    Console.WriteLine($"{guestsOfParty[0]} is already in the list!");
                }
                else if (guestsOfParty.Count == 3 & !peopleGointForSure.Contains(guestsOfParty[0]))
                {
                    peopleGointForSure.Add(guestsOfParty[0]);
                    result.Add(guestsOfParty[0]);
                }
                 if (guestsOfParty.Count == 4 & !peopleGointForSure.Contains(guestsOfParty[0]))
                {
                    Console.WriteLine($"{guestsOfParty[0]} is not in the list!");
                }
                else if (guestsOfParty.Count == 4 && peopleGointForSure.Contains(guestsOfParty[0]))
                {
                    peopleGointForSure.RemoveAll(x => x == guestsOfParty[0]);
                    result.RemoveAll(x => x == guestsOfParty[0]);
                }
            }
            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
        }
    }
}
