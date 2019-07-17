using _01.Vehicles.Exceptions;
using _01.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {

            //carInfo

            string[] carInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumptionPerKm = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            Car car = new Car(carFuelQuantity, carFuelConsumptionPerKm, carTankCapacity);

            //truckInfo

            string[] truckInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumptionPerKm = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumptionPerKm, truckTankCapacity);


            string[] busInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumptionPerKm = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumptionPerKm, busTankCapacity);

            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {

                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = command[0];
                string currentVehicle = command[1];

                if (currentCommand == "DriveEmpty")
                {
                    double distanceToDrive = double.Parse(command[2]);

                    Console.WriteLine(bus.Drive(distanceToDrive));
                }
                if (currentCommand == "Drive")
                {
                    double distanceToDrive = double.Parse(command[2]);

                    if (currentVehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distanceToDrive));
                    }
                    else if (currentVehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distanceToDrive));
                    }
                    else if (currentVehicle == "Bus")
                    {
                        Console.WriteLine(bus.DriveWithPeople(distanceToDrive));
                    }
                }
                try
                {
                    if (currentCommand == "Refuel")
                    {
                        double amountToRefuel = double.Parse(command[2]);

                        if (currentVehicle == "Car")
                        {

                            car.Refuel(amountToRefuel);

                        }
                        else if (currentVehicle == "Truck")
                        {

                            truck.Refuel(amountToRefuel);

                        }
                        else if (currentVehicle == "Bus")
                        {
                            bus.Refuel(amountToRefuel);
                        }
                    }
                }
                catch (FuelMoreThanTankCapacityException fmt )
                {

                    Console.WriteLine(string.Format(fmt.Message, double.Parse(command[2])));
                }
                catch (FuelNegativeNumberException fne)
                {
                    Console.WriteLine(fne.Message);
                }

            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

        }




    }
}
