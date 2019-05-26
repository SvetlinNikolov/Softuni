
namespace _07._The_V_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {

        static void Main(string[] args)
        {
            List<string> allVloggers = new List<string>();

            Dictionary<string, List<string>> vloggerAndFollowers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> vloggerAndPeopleHeFollows = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Statistics")
                {
                    break;
                }
                string firstVlogger = input[0];
                string joinedOrFollowed = input[1];
                string secondVlogger = input[2];

                if (joinedOrFollowed == "joined" && !allVloggers.Contains(firstVlogger))
                {
                    allVloggers.Add(firstVlogger);

                    vloggerAndFollowers[firstVlogger] = new List<string>();
                    vloggerAndPeopleHeFollows[firstVlogger] = new List<string>();
                }
                else if (joinedOrFollowed == "followed" && allVloggers.Contains(firstVlogger) && allVloggers.Contains(secondVlogger))
                {
                    if (firstVlogger != secondVlogger && vloggerAndFollowers.ContainsKey(firstVlogger))
                    {
                        if (!vloggerAndFollowers[secondVlogger].Contains(secondVlogger)
                            && !vloggerAndPeopleHeFollows[secondVlogger].Contains(firstVlogger))
                        {
                            vloggerAndFollowers[secondVlogger].Add(firstVlogger);
                            vloggerAndPeopleHeFollows[firstVlogger].Add(secondVlogger);
                        }

                    }

                }
            }
            Console.WriteLine($"The V-Logger has a total of {allVloggers.Count} vloggers in its logs.");

            

        }
    }
}
