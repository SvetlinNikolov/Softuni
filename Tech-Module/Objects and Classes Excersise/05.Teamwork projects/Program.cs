using System;
using System.Collections.Generic;
using System.Linq;
namespace _05.Teamwork_projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Participants> teamsCreatorsMembers = new List<Participants>();

            for (int i = 0; i <= teamsCount; i++)
            {
                Participants people = new Participants();
                List<string> inputData = Console.ReadLine().Split("-").ToList();


            }
        }
    }
    class Participants
    {
        public string TeamName;
        public string Creator;
        public string Members;

    }
}
