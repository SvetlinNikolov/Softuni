﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods.FoodChildClasses
{
    public class FoodHash : Food
    {

        private const char symbol = '$';
        private const int points = 2;
        public FoodHash(Wall wall) 
            : base(wall, symbol, points)
        {
        }
    }
}
