using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rand = new Random();

            int elementToRemove = rand.Next(0, this.Count);

            string stringToRemove = this[elementToRemove];

            this.Remove(stringToRemove);

            return stringToRemove;

        }
    }
}
