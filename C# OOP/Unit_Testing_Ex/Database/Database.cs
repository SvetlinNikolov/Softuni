using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DatabaseProject
{
    public class Database
    {
        private const int NUMBERS_ARRAY_ALLOWED_CAPACITY = 16;
        private int[] numbersArray;

        private Database()
        {
            this.numbersArray = new int[NUMBERS_ARRAY_ALLOWED_CAPACITY];
        }

        public Database(params int[] initialIntsInArray)
            : this()
        {
            this.NumbersArray = initialIntsInArray;

        }
        public int[] NumbersArray
        {
            get
            {
                return this.numbersArray;
            }
            private set
            {
                if (numbersArray.Length > 16 || value.Length > 16)
                {
                    throw new InvalidOperationException
                        ($"The lenght of the array cannot be more than {NUMBERS_ARRAY_ALLOWED_CAPACITY}");
                }

                this.numbersArray = value;
            }
        }

        public void Add(int numberToAddToArray)
        {

            List<int> currentNumbersArray = NumbersArray.ToList();

            currentNumbersArray.Add(numberToAddToArray);

            NumbersArray = currentNumbersArray.ToArray();

        }
        public void Remove()
        {
            List<int> currentNumbersArray = NumbersArray.ToList();

            currentNumbersArray.Remove(currentNumbersArray.Last());

            NumbersArray = currentNumbersArray.ToArray();
        }
        public int[] Fetch()
        {
            return this.NumbersArray;
        }
        
    }
}
