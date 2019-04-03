using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                Person person = new Person();

                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[0] == "End")
                {
                    break;
                }

                string name = commands[0];
                int id = int.Parse(commands[1]);
                int age = int.Parse(commands[2]);

                person.Name = name;
                person.ID = id;
                person.Age = age;

                people.Add(person);

            }

            people = people.OrderBy(x => x.Age).ToList();

            foreach (var item in people)
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name;
        public int ID;
        public int Age;
    }
}