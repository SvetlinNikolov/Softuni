using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {

            var registeredStudents = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] people = Console.ReadLine().Split(" : ").ToArray();

                if (people[0] == "end")
                {
                    break;
                }
                string course = people[0];
                string student = people[1];


                if (!registeredStudents.ContainsKey(course))
                {
                    registeredStudents.Add(course, new List<string>());
                    registeredStudents[course].Add(student);

                }
                else
                {
                    registeredStudents[course].Add(student);
                }
            }

            foreach (var kvp in registeredStudents.OrderByDescending(i => i.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
