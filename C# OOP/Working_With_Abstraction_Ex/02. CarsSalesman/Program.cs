using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CarsSalesman
{
    public class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            CreateEngines(engines);

            CreateCarsWithEngines(cars, engines);

            PrintCars(cars);
        }

        private static void CreateCarsWithEngines(List<Car> cars, List<Engine> engines)
        {
            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string carModel = parameters[0];

                string engineModel = parameters[1];

                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                int carWeight = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out carWeight))
                {
                    cars.Add(new Car(carModel, engine, carWeight));
                }
                else if (parameters.Length == 3)
                {
                    string carColor = parameters[2];
                    cars.Add(new Car(carModel, engine, carColor));
                }
                else if (parameters.Length == 4)
                {
                    string carColor = parameters[3];
                    cars.Add(new Car(carModel, engine, int.Parse(parameters[2]), carColor));
                }
                else
                {
                    cars.Add(new Car(carModel, engine));
                }
            }
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void CreateEngines(List<Engine> engines)
        {
            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] carInformation = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string engineModel = carInformation[0];
                int enginePower = int.Parse(carInformation[1]);

                int engineDisplacement = -1;

                if (carInformation.Length == 3 && int.TryParse(carInformation[2], out engineDisplacement))
                {
                    engines.Add(new Engine(engineModel, enginePower, engineDisplacement));
                }
                else if (carInformation.Length == 3)
                {
                    string engineEfficiency = carInformation[2];
                    engines.Add(new Engine(engineModel, enginePower, engineEfficiency));
                }
                else if (carInformation.Length == 4)
                {
                    string engineEfficiency = carInformation[3];
                    engines.Add(new Engine(engineModel, enginePower, int.Parse(carInformation[2]), engineEfficiency));
                }
                else
                {
                    engines.Add(new Engine(engineModel, enginePower));
                }
            }
        }
    }

}
