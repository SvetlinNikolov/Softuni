using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Tire
    {
        private int year;
        private double pressure;

        public int Year;
        public double Pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;

        }
    }
}
