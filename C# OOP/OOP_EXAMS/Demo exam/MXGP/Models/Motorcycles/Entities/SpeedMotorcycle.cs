using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles.Entities
{
    public class SpeedMotorcycle : Motorcycle
    {
        //NEED TO FINISH HORSEPOWER LOGIC HERE TOO

        private const int MINIMUM_HORSEPOWER = 50;
        private const int MAXIMUM_HORSEPOWER = 69;

        private int horsePower;

        private const double SPEED_MOTORCYCLE_CUBIC_CENTIMETERS = 125;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, SPEED_MOTORCYCLE_CUBIC_CENTIMETERS)
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