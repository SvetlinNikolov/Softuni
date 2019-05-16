using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>(Console.ReadLine().Split());

            Stack<string> servedCars = new Stack<string>();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "End")
            {
                string[] carInfo = command[0].Split('-');

                if (command[0] == "Service")
                {
                    if (cars.Count > 0)
                    {
                        string servedCar = cars.Dequeue();
                        servedCars.Push(servedCar);
                        Console.WriteLine($"Vehicle {servedCar} got served.");
                    }

                }
                else if (carInfo[0] == "CarInfo")
                {
                    string carInService = carInfo[1];

                    if (cars.Contains(carInService))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else if (servedCars.Contains(carInService))
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (command[0] == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars));
                }
                command = Console.ReadLine().Split().ToArray();
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", cars)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");

        }
    }
}