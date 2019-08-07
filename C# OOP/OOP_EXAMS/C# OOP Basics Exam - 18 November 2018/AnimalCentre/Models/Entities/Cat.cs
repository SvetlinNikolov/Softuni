using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public class Cat : Animal,IAnimal
    {
        public Cat(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine
                ($"Animal type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}");

            return sb.ToString().TrimEnd();
        }
    }
}
