using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Car_Salesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            List<Car> cars = new List<Car>();

            AddEnginesToList(enginesCount, engines);

            int carsCount = int.Parse(Console.ReadLine());

            AddCarsWithEngines(engines, cars, carsCount);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"   Power: {car.Engine.Power}");
                Console.WriteLine($"   Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"   Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }

        private static void AddCarsWithEngines(List<Engine> engines, List<Car> cars, int carsCount)
        {
            for (int i = 0; i < carsCount; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = currentCar[0];
                string engineModel = currentCar[1];

                Engine engine = engines.Where(e => e.Model == currentCar[1]).ToList()[0];

                if (currentCar.Length == 4)
                {
                    string weight = currentCar[2];
                    string color = currentCar[3];

                    Car car = new Car(carModel, engine, weight, color);
                    cars.Add(car);
                }
                else if (currentCar.Length == 3)
                {
                    string weight = currentCar[2];

                    Car car = new Car(carModel, engine, weight);
                    cars.Add(car);
                }
                else if (currentCar.Length == 2)
                {
                    Car car = new Car(carModel, engine);
                    cars.Add(car);
                }
            }
        }


        private static void AddEnginesToList(int enginesCount, List<Engine> engines)
        {
            for (int i = 0; i < enginesCount; i++)
            {
                string[] currentEngine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currentEngine.Length == 4)
                {
                    string model = currentEngine[0];
                    int power = int.Parse(currentEngine[1]);
                    string displacement = currentEngine[2];
                    string efficiency = currentEngine[3];

                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
                else if (currentEngine.Length == 3)
                {
                    string model = currentEngine[0];
                    int power = int.Parse(currentEngine[1]);
                    string displacement = currentEngine[2];

                    Engine engine = new Engine(model, power, displacement);
                    engines.Add(engine);
                }
                else if (currentEngine.Length == 2)
                {
                    string model = currentEngine[0];
                    int power = int.Parse(currentEngine[1]);

                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
            }
        }
    }
}
