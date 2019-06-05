using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower;
        public double CubicCapacity;

        public Engine(int horsePower, int cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}
