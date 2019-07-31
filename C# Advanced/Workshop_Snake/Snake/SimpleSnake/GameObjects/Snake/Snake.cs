using SimpleSnake.GameObjects.Foods;
using SimpleSnake.GameObjects.Foods.FoodChildClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Snake
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.foods = new Food[3];
            this.snakeElements = new Queue<Point>();
            this.foodIndex = RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }
        public int RandomFoodNumber => new Random().Next(0, this.foods.Length);
        public bool IsMoving(Point direction)
        {
            Point snakeHead = this.snakeElements.Last();
            this.GetNextPoint(direction, snakeHead);

            bool isPointOfSnake = this.snakeElements.Any(p => p.LeftX == this.nextLeftX
            && p.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }
            Point snakeNewHead = new Point(this.nextLeftX, nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }
            this.snakeElements.Enqueue(snakeHead);
            snakeNewHead.Draw(snakeSymbol);

            if (this.foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, snakeHead);
            }
            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }
        public void Eat(Point direction, Point currentSnakeHead)
        {
            int lenght = this.foods[foodIndex].FoodPoints;

            for (int i = 0; i < lenght; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);

            }
            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }
        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
        public Snake()
        {

        }

        //May have to create food 
        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }
        private void GetFoods()
        {
            this.foods[0] = new FoodAsterisk(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodHash(this.wall);
        }
    }
}
