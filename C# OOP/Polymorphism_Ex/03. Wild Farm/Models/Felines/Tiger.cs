using _03._Wild_Farm.Models.Entities;
using _03._Wild_Farm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Models.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight,  livingRegion, breed)
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
            return "ROAR!!!";
        }
    }
}
