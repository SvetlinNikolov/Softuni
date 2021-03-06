﻿using _01.Vehicles.Exceptions;
using _01.Vehicles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public class Car : IVehicle
    {
        private const double AIR_CONDITIONER_FUEL_CONSUMPTION = 0.9;
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
                    throw new FuelMoreThanTankCapacityException();

                }
                this.fuelQuantity = value;
            }
        }

        public Car(double fuelQuantity, double fuelConsumtionPerKm, double tankCapacity)
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
            if (fuelAmount <= 0)
            {
                throw new FuelNegativeNumberException();
            }
            this.FuelQuantity += fuelAmount;
        }


    }
}
