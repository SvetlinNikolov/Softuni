﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods.FoodChildClasses
{
    public class FoodDollar : Food
    {

        private const char symbol = '$';
        private const int points = 2;
        public FoodDollar(Wall wall) 
            : base(wall, symbol, points)
        {
        }
    }
}
