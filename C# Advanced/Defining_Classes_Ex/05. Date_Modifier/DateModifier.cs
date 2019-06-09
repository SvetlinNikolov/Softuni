using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public double DaysDifference(string[] first, string[] second)
        {
            DateTime firstDate = new DateTime(Parser(first[0]), Parser(first[1]), Parser(first[2]));
            DateTime secondDate = new DateTime(Parser(second[0]), Parser(second[1]), Parser(second[2]));

            return (firstDate - secondDate).TotalDays;
        }
        public int Parser(string textToParse)
        {
            return int.Parse(textToParse);
        }
    }

}

