using System;

namespace Logger.Exceptions
{
    public class InvalidLevelTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid Level Type!";

        public InvalidLevelTypeException()
            : base (EXCEPTION_MESSAGE)
        {
        }

        public InvalidLevelTypeException(string message) : base(message)
        {
        }
    }
}
