using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _01.Vehicles.Exceptions
{
    public class FuelNegativeNumberException : Exception
    {
        private const string MESSAGE = "Fuel must be a positive number";

        public FuelNegativeNumberException()
            : base(MESSAGE)
        {
        }


    }
}
