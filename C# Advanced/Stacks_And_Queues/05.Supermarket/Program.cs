using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            Queue<string> queueOfPeople = new Queue<string>();

            while (names != "End")
            {
                if (names == "Paid")
                {
                    foreach (var person in queueOfPeople)
                    {
                        Console.WriteLine(person);
                    }
                    queueOfPeople.Clear();
                }
                if (names != "Paid")
                {
                    queueOfPeople.Enqueue(names);
                    
                }
                names = Console.ReadLine();
            }
            Console.WriteLine($"{queueOfPeople.Count} people remaining.");

        }
    }
}
