using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _01.Vehicles.Exceptions
{
    public class FuelMoreThanTankCapacityException : Exception
    {
        public const string MESSAGE = "Cannot fit {0} fuel in the tank";

        public FuelMoreThanTankCapacityException()
            : base(MESSAGE)
        {
        }

        
    }
}
