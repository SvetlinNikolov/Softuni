using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core.Contracts
{
    public interface IFoodFactory
    {
        IFood CreateFood(string foodType, string foodName, decimal foodPrice);
    }
}
