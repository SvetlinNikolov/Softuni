using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Tire
    {
        public double TirePressure { get; set; }

        public int TireAge { get; set; }

        public Tire(double pressure, int age)
        {
            this.TirePressure = pressure;
            this.TireAge = age;
        }
    }
}
