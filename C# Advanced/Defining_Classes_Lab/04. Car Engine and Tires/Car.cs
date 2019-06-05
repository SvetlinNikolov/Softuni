using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        //fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private int tireYear;
        private double tirePressure;
        private Engine engine;
        private Tire[] tire;

        //properties
        public string Make;
        public string Model;
        public int Year;
        public double FuelQuantity;
        public double FuelConsumption;
        public int TireYear;
        public double TirePressure;
        public Engine Engine;
        public Tire[] Tire;
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumtion)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtion;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumtion, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumtion)
        {
            this.Engine = engine;
            this.Tire = tires;
        }

    }

}
