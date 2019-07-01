using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Tire
    {
        private double tire1Pressure;
        private int tire1age;

        //private double tire2Pressure;
        //private int tire2age;

        //private double tire3Pressure;
        //private int tire3age;

        //private double tire4Pressure;
        //private int tire4age;

        public Tire(double tirePressure, int tireAge)
        {
            this.Tire1Pressure = tirePressure;
            this.Tire1age = tireAge;
        }

        public double Tire1Pressure { get => tire1Pressure; set => tire1Pressure = value; }
        public int Tire1age { get => tire1age; set => tire1age = value; }
    }
}
