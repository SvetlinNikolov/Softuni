using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }
        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldestPerson = people.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }
        public List<Person> AgeOver30()
        {
            List<Person> peopleOver30 = new List<Person>();

            foreach (var person in this.people)
            {
                if (person.Age > 30)
                {
                    peopleOver30.Add(person);
                }   
            }
            return peopleOver30;
        }

    }
}
