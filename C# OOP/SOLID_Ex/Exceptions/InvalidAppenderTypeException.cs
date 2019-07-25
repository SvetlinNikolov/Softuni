using System;

namespace Logger.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid Appender Type Exception!";

        public InvalidAppenderTypeException()
            : base(EXCEPTION_MESSAGE)
        {
        }

        public InvalidAppenderTypeException(string message) : base(message)
        {
        }
    }
}
