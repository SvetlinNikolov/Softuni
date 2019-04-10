using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _01.Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();

            var gamesWithDlc = new Dictionary<string, List<string>>();
            var gamesAndPrice = new Dictionary<string, double>();

            List<string> gamesWithoutDlc = new List<string>();

            string pattern = @"^[A-Za-z0-9 ]+$";
            Regex gameRegex = new Regex(pattern);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains('-'))
                {
                    string[] currentGameAndPrice = input[i].Split("-").ToArray();

                    string currentgame = currentGameAndPrice[0];
                    double currentPrice = double.Parse(currentGameAndPrice[1]);

                    if (gameRegex.IsMatch(currentgame))
                    {
                        if (gamesAndPrice.ContainsKey(currentgame))
                        {
                            gamesAndPrice[currentgame] = currentPrice;
                        }
                        else if (!gamesAndPrice.ContainsKey(currentgame))
                        {
                            gamesAndPrice.Add(currentgame, currentPrice);
                        }

                    }
                }
                if (input[i].Contains(":"))
                {
                    string[] gameAndDlc = input[i].Split(":").ToArray();

                    string currentgame = gameAndDlc[0];
                    string currentDlc = gameAndDlc[1];

                    if (gameRegex.IsMatch(currentgame))
                    {
                        if (gamesAndPrice.ContainsKey(currentgame))
                        {
                            gamesWithDlc.Add(currentgame, new List<string>());
                            gamesWithDlc[currentgame].Add(currentDlc);
                        }
                    }
                }
            }
            foreach (var game in gamesWithDlc.Keys)
            {
                gamesAndPrice[game] += gamesAndPrice[game] * 0.20;
            }
            foreach (var game in gamesAndPrice.ToList())
            {

                if (!gamesWithDlc.ContainsKey(game.Key))
                {
                    gamesAndPrice[game.Key] -= gamesAndPrice[game.Key] * 0.20;
                }
                else
                {
                    gamesAndPrice[game.Key] -= gamesAndPrice[game.Key] * 0.50;
                }
            }
            //here we add to gamesWithoutDlc, the games that dont have dlc so we can print them
           
            foreach (var kvp in gamesAndPrice.OrderBy(x => x.Value))
            {
                if (gamesWithDlc.ContainsKey(kvp.Key))
                {
                    Console.Write(kvp.Key + " - ");
                    foreach (var value in gamesWithDlc[kvp.Key])
                    {
                        Console.Write(value+" - ");
                    }
                    Console.WriteLine($"{kvp.Value:f2}");
                }
            }
            foreach (var gameNoDlc in gamesAndPrice.OrderByDescending(x=>x.Value))
            {
                if (!gamesWithDlc.ContainsKey(gameNoDlc.Key))
                {
                    Console.WriteLine($"{gameNoDlc.Key} - {gameNoDlc.Value:f2}");
                }
            }


        }
    }
}
