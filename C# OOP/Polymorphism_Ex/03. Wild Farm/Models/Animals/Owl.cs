using _03._Wild_Farm.Models.Entities;
using _03._Wild_Farm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        protected override List<Type> prefferedFoods
        {
            get
            {
                return new List<Type>() { typeof(Meat) };
            }
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
