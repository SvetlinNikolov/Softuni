using SoftUniRestaurant.Core.Contracts;
using SoftUniRestaurant.Models.Entities;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string foodType, string foodName, decimal foodPrice)
        {
            IFood createdFood = null;

            switch (foodType.ToLower())
            {
                case "dessert":
                    createdFood = new Dessert(foodName, foodPrice);
                    break;
                case "maincourse":
                    createdFood = new MainCourse(foodName, foodPrice);
                    break;
                case "salad":
                    createdFood = new Salad(foodName, foodPrice);
                    break;
                case "soup":
                    createdFood = new Soup(foodName, foodPrice);
                    break;
            }
            return createdFood;
        }

       
    }
}
