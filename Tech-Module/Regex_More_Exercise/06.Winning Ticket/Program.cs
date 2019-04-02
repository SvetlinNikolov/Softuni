using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace _06.Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tickets = Console.ReadLine().Split(", ").Select(x => x.Trim()).ToList();

            string sixRepeatingSymbols = @"([@]{6,})|([$]{6,})|([\^]{6,})|([#]{6,})";
            Regex miniJackpot = new Regex(sixRepeatingSymbols);

            string tenRepeatingSymbols = @"([@]{10})|([$]{10})|([\^]{10})|([#]{10})";
            Regex megaJackpot = new Regex(tenRepeatingSymbols);

            for (int i = 0; i < tickets.Count; i++)
            {
                string currentTicket = tickets[i];

                if (currentTicket.Length < 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string firstHalfOfString = currentTicket.Substring(0, currentTicket.Length / 2);
                string secondHalfOfString = currentTicket.Substring(currentTicket.Length / 2);

                if (megaJackpot.IsMatch(firstHalfOfString))
                {

                    if (megaJackpot.IsMatch(secondHalfOfString))
                    {
                        var matchingSymbol = miniJackpot.Match(secondHalfOfString);

                        Console.WriteLine($"ticket \"{currentTicket}\" - 10{matchingSymbol.Value[0]} Jackpot!");
                    }
                }
                else if (miniJackpot.IsMatch(firstHalfOfString))
                {
                    if (miniJackpot.IsMatch(secondHalfOfString))
                    {
                        var matchingSymbol = miniJackpot.Match(secondHalfOfString);
                        Console.WriteLine($"ticket \"{currentTicket}\" - 6{matchingSymbol.Value[0]}");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                }

            }
        }
    }
}
