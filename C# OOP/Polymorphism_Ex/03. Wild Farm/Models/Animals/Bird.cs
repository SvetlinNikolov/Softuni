using _03._Wild_Farm.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Models.Animals
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten,double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

            
    }
}
