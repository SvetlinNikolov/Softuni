using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Car_Salesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; } = "n/a";
        public string Color { get; set; } = "n/a";

        public Car(string model, Engine engine, string weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public Car(string model, Engine engine,string weight)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
        }
        public Car(string model, Engine engine)

        {
            this.Model = model;
            this.Engine = engine;
        }

    }
}
