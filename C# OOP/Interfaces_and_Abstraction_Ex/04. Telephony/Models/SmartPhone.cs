using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace _04._Telephony
{
    public class SmartPhone : IInternetBrowsable, ICallable
    {
      
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidUrlException();
            }
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.Any(x => char.IsDigit(x)))
            {
                throw new InvalidNumberException();
            }
            return $"Calling... {number}";
        }
    }
}
