using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles.Entities
{
    public class PowerMotorcycle : Motorcycle
    {
  
        private int horsePower;

        private const int MINIMUM_HORSEPOWER = 70;
        private const int MAXIMUM_HORSEPOWER = 100;

        private const double POWER_MOTORCYCLE_CUBIC_CENTIMETERS = 450;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, POWER_MOTORCYCLE_CUBIC_CENTIMETERS)
        {


        }

        public override int HorsePower

        {
            get
            {

                return this.horsePower;
            }
            protected set
            {
                if (value < MINIMUM_HORSEPOWER || value > MAXIMUM_HORSEPOWER)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }
    }
}
