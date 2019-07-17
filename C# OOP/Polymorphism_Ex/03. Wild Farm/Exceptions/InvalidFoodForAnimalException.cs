using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _03._Wild_Farm.Exceptions
{
    public class InvalidFoodForAnimalException:Exception
    {
        private const string MESSAGE = "{0} does not eat {1}!";

        public InvalidFoodForAnimalException()
            : base(MESSAGE)
        {
        }

       
    }
}
