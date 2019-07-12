using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Telephony
{
    public class InvalidUrlException:Exception
    {
        private const string MESSAGE = "Invalid URL!";

        public InvalidUrlException()
            : base(MESSAGE)
        {

        }
        
    }
}
