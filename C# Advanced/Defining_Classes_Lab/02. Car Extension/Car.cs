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

        //properties
        public string Make;
        public string Model;
        public int Year;
        public double FuelQuantity;
        public double FuelConsumption;

        public void Drive(double distance)
        {
            if (this.FuelQuantity - distance > 0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
                
            }
        }
        public string WhoAmI()
        {
            return $"Make: { this.Make}\nModel: { this.Model}\nYear: { this.Year}\nFuel: { this.FuelQuantity:F2}L";
           
        }

    }
    
}
