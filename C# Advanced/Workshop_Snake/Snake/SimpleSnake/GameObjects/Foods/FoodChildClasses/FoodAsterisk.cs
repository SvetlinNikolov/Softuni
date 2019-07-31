using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods.FoodChildClasses
{
    public class FoodAsterisk : Food
    {
        private const char symbol = '*';
        private const int points = 1;   
        public FoodAsterisk(Wall wall)
            : base(wall, symbol, points)
        {

        }
    }
}
