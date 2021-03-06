﻿using _03._Wild_Farm.Models.Entities;
using _03._Wild_Farm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Models.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, livingRegion)
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
            return "Woof!";
        }
    }
}
