using _03._Wild_Farm.Models.Entities;
using _03._Wild_Farm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Models.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        protected override List<Type> prefferedFoods
        {
            get
            {
                return new List<Type>() { typeof(Meat), typeof(Vegetable) };
            }
        }
        public override string AskForFood()
        {
            return "Meow";
        }

        public  void Feed(Food food)
        {
            base.Feed(food);
            this.Weight += 0.30;
        }
    }
}
