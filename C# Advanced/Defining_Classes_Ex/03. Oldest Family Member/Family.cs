using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldestPerson = people.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }

    }
}
