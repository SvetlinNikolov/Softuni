using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Ex
{
    public class Sandwich:SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;
  

        private string GetIngredientList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredientList = GetIngredientList();

            Console.WriteLine($"Cloning sandwich with ingredients: {ingredientList}");

            return MemberwiseClone() as SandwichPrototype;
        }
        
    }
}
