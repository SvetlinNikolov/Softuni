using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            var carsRegistered = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] users = Console.ReadLine().Split().ToArray();

                if (users[0] == "register")
                {
                    string personName = users[1];
                    string carNumber = users[2];

                    if (!carsRegistered.ContainsKey(personName))
                    {
                        carsRegistered.Add(personName, carNumber);
                        Console.WriteLine($"{personName} registered {carNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {carsRegistered[personName]}");
                    }
                }
                if (users[0] == "unregister")
                {
                    string personName = users[1];


                    if (!carsRegistered.ContainsKey(personName))
                    {
                        Console.WriteLine($"ERROR: user {personName} not found");
                    }
                    else
                    {
                        carsRegistered.Remove(personName);
                        Console.WriteLine($"{personName} unregistered successfully");
                    }
                }
            }
            foreach (var kvp in carsRegistered)
            {
                Console.WriteLine(kvp.Key + " => " + kvp.Value);
            }
        }
    }
}
