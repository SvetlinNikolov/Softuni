using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Telephony
{
    public class InvalidNumberException : Exception
    {
        private const string MESSAGE = "Invalid number!";

        public InvalidNumberException()
            : base(MESSAGE)
        {

        }
    }
}
