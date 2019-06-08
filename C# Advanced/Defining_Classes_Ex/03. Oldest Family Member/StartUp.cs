using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int familyMembers = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < familyMembers; i++)
            {
                string[] currentPersonAndAge = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currentPerson = currentPersonAndAge[0];
                int personAge = int.Parse(currentPersonAndAge[1]);

                Person person = new Person(currentPerson, personAge);
                family.AddMember(person);
            }
            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
