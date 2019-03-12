using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Quest_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Retire!")
            {
                string[] quests = command.Split(" - ").ToArray();
                string currentCommand = quests[0];
                string currentQuest = quests[1];
                

                if (currentCommand == "Start")
                {
                    if (!journal.Contains(currentQuest))
                    {
                        journal.Add(currentQuest);
                    }
                }
                if (currentCommand == "Complete")
                {
                    if (journal.Contains(currentQuest))
                    {
                        journal.Remove(currentQuest);
                    }
                }
                if (currentCommand == "Side Quest")
                {
                    List<string> sideQuestSplit = currentQuest.Split(":").ToList();
                    if (journal.Contains(sideQuestSplit[0]))
                    {
                        int index = journal.IndexOf(sideQuestSplit[0]);
                        if (!journal.Contains(sideQuestSplit[1]))
                        {
                            journal.Insert(index + 1, sideQuestSplit[1]);
                        }

                    }
                }
                if (currentCommand == "Renew")
                {
                    if (journal.Contains(currentQuest))
                    {
                        string tempCurrentQuest = currentQuest;
                        journal.Remove(currentQuest);
                        journal.Add(tempCurrentQuest);
                    }
                }
                command = Console.ReadLine();
            }
            Console.Write(string.Join(", ", journal));
        }
    }
}
