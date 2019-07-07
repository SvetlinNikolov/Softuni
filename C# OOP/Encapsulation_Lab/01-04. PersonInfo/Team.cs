
using PersonsInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Team
    {
        private string name;

        private List<Person> firstTeam;
        private List<Person> reverseTeam;

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }

        }
        public IReadOnlyCollection<Person> ReverseTeam
        {
            get { return this.reverseTeam.AsReadOnly(); }

        }

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reverseTeam = new List<Person>();

        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reverseTeam.Add(person);
            }
        }
    }
}
