using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personAndAge = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string person = personAndAge[0];
                int age = int.Parse(personAndAge[1]);

                Person currentPerson = new Person(person, age);
                family.AddMember(currentPerson);
            }
            List<Person> peopleAbove30 = family.AgeOver30();

            foreach (var person in peopleAbove30.OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
