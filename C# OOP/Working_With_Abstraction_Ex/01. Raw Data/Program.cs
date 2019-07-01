using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{

    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] carParameters = Console.ReadLine()
                    .Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries);

                string model = carParameters[0];

                int engineSpeed = int.Parse(carParameters[1]);
                int enginePower = int.Parse(carParameters[2]);

                int cargoWeight = int.Parse(carParameters[3]);
                string cargoType = carParameters[4];

                double tire1Pressure = double.Parse(carParameters[5]);
                int tire1age = int.Parse(carParameters[6]);

                double tire2Pressure = double.Parse(carParameters[7]);
                int tire2age = int.Parse(carParameters[8]);

                double tire3Pressure = double.Parse(carParameters[9]);
                int tire3age = int.Parse(carParameters[10]);

                double tire4Pressure = double.Parse(carParameters[11]);
                int tire4age = int.Parse(carParameters[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire tire1 = new Tire(tire1Pressure, tire1age);
                Tire tire2 = new Tire(tire2Pressure, tire2age);
                Tire tire3 = new Tire(tire3Pressure, tire3age);
                Tire tire4 = new Tire(tire4Pressure, tire4age);

                Car car = new Car(model, engine, cargo, new Tire[] { tire1, tire2, tire3, tire4 });
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Tires.Any(t => t.Tire1Pressure < 1))
                    .Where(y => y.Cargo.CargoType == "fragile")
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));

            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
