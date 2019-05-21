using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                if (commands[0] == "END")
                {
                    break;
                }
                string direction = commands[0];
                string carNumberPlate = commands[1];

                if (direction == "IN")
                {
                    cars.Add(carNumberPlate);
                }
                else if (direction == "OUT")
                {
                    cars.Remove(carNumberPlate);
                }
                commands = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
