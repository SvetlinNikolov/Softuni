using _03._Wild_Farm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Models.Entities
{
    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; }
    }
}
