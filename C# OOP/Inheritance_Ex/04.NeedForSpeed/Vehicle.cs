﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public double DefaultFuelConsumtion => 1.25;
        public virtual double FuelConsumtion { get; set; }

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * DefaultFuelConsumtion;
        }
    }
}
