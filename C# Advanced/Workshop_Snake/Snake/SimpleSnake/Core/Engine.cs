using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Snake;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Direction direction;
        private Point[] pointsOfDirections;
        private Snake snake;
        private Wall wall;
        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;

            this.pointsOfDirections = new Point[4];
            this.sleepTime = 100;
            
        }
        public void Run()
        {
            this.CreateDirecitons();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving
                    (this.pointsOfDirections[(int)this.direction]);

                if (!isMoving)
                {
                    this.AskUserForRestart();

                }
                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);

            Console.WriteLine("Would you like to continue? да/не мамо");

            string input = Console.ReadLine();

            if (input == " y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else if (input == " n")
            {

            }

        }
        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Играта свърши браат");
            Environment.Exit(0);
        }
        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }
        private void CreateDirecitons()
        {
            this.pointsOfDirections[0] = new Point(1, 0);
            this.pointsOfDirections[1] = new Point(-1, 0);
            this.pointsOfDirections[2] = new Point(0, 1);
            this.pointsOfDirections[3] = new Point(0, -1);

        }
    }
}
