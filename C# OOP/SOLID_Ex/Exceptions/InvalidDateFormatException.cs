using System;

namespace Logger.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid Date time Format!"; 

        public InvalidDateFormatException()
            : base (EXCEPTION_MESSAGE)
        {
        }

        public InvalidDateFormatException(string message) : base(message)
        {
        }

        public InvalidDateFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
