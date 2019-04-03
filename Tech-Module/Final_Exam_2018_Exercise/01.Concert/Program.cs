using System;
using System.Linq;
using System.Collections.Generic;
namespace _01___Concert
{
    class Program
    {
        static void Main(string[] args)
        {

            var concertPlayers = new Dictionary<string, List<string>>();

            var bandAndTimeOnStage = new Dictionary<string, long>();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "start of concert")
                {
                    break;
                }

                string[] getInitialCommand = commands.Split("; ", ',').ToArray();

                if (getInitialCommand[0] == "Add")
                {
                    string band = getInitialCommand[1];
                    string[] bandMembers = getInitialCommand[2].Split(", ");


                    if (!concertPlayers.ContainsKey(band))
                    {
                        concertPlayers.Add(band, new List<string>());

                        foreach (var bandMember in bandMembers)
                        {
                            concertPlayers[band].Add(bandMember);
                        }

                    }
                    else if (concertPlayers.ContainsKey(band))
                    {
                        foreach (var bandMember in bandMembers)
                        {
                            if (!concertPlayers[band].Contains(bandMember))
                            {
                                concertPlayers[band].Add(bandMember);
                            }
                        }
                    }

                }

                else if (getInitialCommand[0] == "Play")
                {
                    string playingBand = getInitialCommand[1];

                    long timePlayed = long.Parse(getInitialCommand[2]);

                    if (concertPlayers.ContainsKey(playingBand))
                    {
                        if (bandAndTimeOnStage.ContainsKey(playingBand))
                        {
                            bandAndTimeOnStage[playingBand] += timePlayed;
                        }
                        else
                        {
                            bandAndTimeOnStage.Add(playingBand, timePlayed);
                        }
                    }
                    else if (bandAndTimeOnStage.ContainsKey(playingBand))
                    {
                        bandAndTimeOnStage[playingBand] += timePlayed;

                    }
                    else
                    {
                        bandAndTimeOnStage.Add(playingBand, timePlayed);
                    }
                }

            }
            string finalBandName = Console.ReadLine();

            long totalTime = bandAndTimeOnStage.Sum(x => x.Value);
            Console.WriteLine($"Total time: {totalTime}");

            foreach (var kvp in bandAndTimeOnStage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine(finalBandName);
            foreach (var member in concertPlayers[finalBandName])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}