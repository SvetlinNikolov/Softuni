using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Car
    {
        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
        public Tire Tire1 { get; set; }
        public Tire Tire2 { get; set; }
        public Tire Tire3 { get; set; }
        public Tire Tire4 { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tire tire1, Tire tire2,Tire tire3, Tire tire4)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;

            this.Tire1 = tire1;
            this.Tire2 = tire2;
            this.Tire3 = tire3;
            this.Tire4 = tire4;
        }
        public Car()
        {

        }
    }
}
