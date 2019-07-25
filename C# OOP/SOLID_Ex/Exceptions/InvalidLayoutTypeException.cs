using System;

namespace Logger.Exceptions
{
    public class InvalidLayoutTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid Layout Type!";

        public InvalidLayoutTypeException()
            : base(EXCEPTION_MESSAGE)
        {
        }

        public InvalidLayoutTypeException(string message) : base(message)
        {
        }
    }
}
