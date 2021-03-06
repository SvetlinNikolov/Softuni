﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Car_Salesman
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; } = "n/a";
        public string Efficiency { get; set; } = "n/a";

        public Engine(string model, int power, string displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, int power,string displacement)
            
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
        }
    }
}
