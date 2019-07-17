using _01.Vehicles.Exceptions;
using _01.Vehicles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public class Truck : IVehicle
    {
        private const double AIR_CONDITIONER_FUEL_CONSUMPTION = 1.6;

        private double fuelConsumtionPerKm;

        private double fuelQuantity;
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                if (value > TankCapacity)
                {

                    this.fuelQuantity = 0;
                }
                this.fuelQuantity = value;
            }
        }


        public Truck(double fuelQuantity, double fuelConsumtionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumtionPerKm = fuelConsumtionPerKm;

        }


        public double FuelConsumtionPerKm
        {
            get
            {
                return this.fuelConsumtionPerKm;
            }
            private set
            {
                this.fuelConsumtionPerKm
                    = value + AIR_CONDITIONER_FUEL_CONSUMPTION;
            }
        }

        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumtionPerKm;

            if (this.FuelQuantity - fuelNeeded >= 0)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";

            }
            return $"{this.GetType().Name} needs refueling";
        }

        public void Refuel(double fuelAmount)
        {
            //adds 95% fuel to truck
            double fuelToRefuel = fuelAmount - fuelAmount * 0.05;

            if (fuelToRefuel <= 0)
            {
                throw new FuelNegativeNumberException();
            }
            if (fuelToRefuel > TankCapacity)
            {
                throw new FuelMoreThanTankCapacityException();
            }
            this.FuelQuantity += fuelToRefuel;
        }
    }
}
