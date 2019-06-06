using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        //fields
        private string make;
        private string model;
        private int year;

        //properties
        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public int Year;

    }
}
