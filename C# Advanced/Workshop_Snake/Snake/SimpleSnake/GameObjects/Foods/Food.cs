using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wall;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.random = new Random();
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
        }
        public int FoodPoints { get; set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, this.LeftX - 2);
            this.TopY = random.Next(2, this.TopY - 2);

            bool isPointOnSnake = snakeElements
                .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            while (isPointOnSnake)
            {
                this.LeftX = random.Next(2, this.LeftX - 2);
                this.TopY = random.Next(2, this.TopY - 2);

                isPointOnSnake = snakeElements
             .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.Yellow;



        }
        public bool IsFoodPoint(Point snakeHead)
        {
            return snakeHead.TopY == this.TopY &&
                snakeHead.LeftX == this.LeftX;
        }
    }
}
