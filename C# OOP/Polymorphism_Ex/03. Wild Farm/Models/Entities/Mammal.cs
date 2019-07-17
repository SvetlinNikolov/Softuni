using _03._Wild_Farm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Models.Entities
{
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; }
    }
}
