using _03._Wild_Farm.Interfaces;
using _03._Wild_Farm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _03._Wild_Farm.Exceptions;
namespace _03._Wild_Farm.Models.Entities
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            
        }
        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        protected abstract List<Type> prefferedFoods { get; }
        public abstract string AskForFood();

        public void Feed(Food food)
        {
            if (!this.prefferedFoods.Contains(food.GetType()))
            {
                throw new InvalidFoodForAnimalException();
            }

        }
    }
}
