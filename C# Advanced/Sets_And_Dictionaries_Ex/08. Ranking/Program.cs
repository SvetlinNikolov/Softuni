
namespace _08._Ranking
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPasswordInput = new Dictionary<string, string>();

            var contestContestantsAndPoints = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] contestAndPassword = Console.ReadLine()
                .Split(":")
                .ToArray();

                if (contestAndPassword[0] == "end of contests")
                {
                    break;
                }

                if (contestAndPassword.Length != 2)
                {
                    continue;
                }
                string contest = contestAndPassword[0];
                string password = contestAndPassword[1];

                contestAndPasswordInput[contest] = password;

            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split("=>");

                if (input[0] == "end of submissions")
                {
                    break;
                }

                if (input.Length != 4)
                {
                    continue;
                }
                if (contestAndPasswordInput.ContainsKey(input[0]) && contestAndPasswordInput[input[0]] == input[1])
                {
                    string contest = string.Empty;
                    string person = string.Empty;
                    int points = 0;

                    try
                    {
                        contest = input[0];
                        person = input[2];
                        points = int.Parse(input[3]);
                    }
                    catch
                    {
                        continue;
                    }

                    //here starts addition to dict

                    if (!contestContestantsAndPoints.ContainsKey(person))
                    {
                        contestContestantsAndPoints[person] = new Dictionary<string, int>();
                        contestContestantsAndPoints[person][contest] = points;
                    }
                    else if (contestContestantsAndPoints.ContainsKey(person))
                    {
                        if (contestContestantsAndPoints[person].ContainsKey(contest))
                        {
                            if (contestContestantsAndPoints[person][contest] < points)
                            {
                                contestContestantsAndPoints[person][contest] = points;
                            }
                        }
                        else if (!contestContestantsAndPoints[person].ContainsKey(contest))
                        {

                            contestContestantsAndPoints[person][contest] = points;
                        }

                    }

                }

            }

            int maxSum = 0;
            int tempSum = 0;
            string bestCandidate = string.Empty;
            string tempCandidate = string.Empty;
            foreach (var value in contestContestantsAndPoints)
            {

                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                    bestCandidate = tempCandidate;
                }
                tempSum = 0;
                foreach (var kvp in value.Value)
                {
                    tempCandidate = value.Key;
                    tempSum += kvp.Value;
                }

            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxSum} points.");
            Console.WriteLine("Ranking: ");
            foreach (var kvp in contestContestantsAndPoints.OrderBy(x => x.Key))
            {
                string currentPerson = kvp.Key;

                Console.WriteLine(currentPerson);

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
