using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split().ToList();

            List<Person> dataOfPeople = new List<Person>();

            while (data[0] != "End")
            {
                Person person = new Person();

                person.Name = data[0];
                person.Id = data[1];
                person.Age = int.Parse(data[2]);

                dataOfPeople.Add(person);

                data = Console.ReadLine().Split().ToList();
            }
            dataOfPeople = dataOfPeople.OrderBy(x => x.Age).ToList();

            foreach (var person in dataOfPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }
    class Person
    {
        public string Name;
        public string Id;
        public int Age;
    }

}
