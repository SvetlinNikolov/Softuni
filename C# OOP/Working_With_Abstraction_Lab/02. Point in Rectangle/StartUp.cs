using System;
using System.Linq;

namespace _02._Point_in_Rectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Point pointX = new Point(coordinates[0], coordinates[1]);
            Point pointY = new Point(coordinates[2], coordinates[3]);

            Rectangle rectangle = new Rectangle(pointX, pointY);

            int countInput = int.Parse(Console.ReadLine());

            CheckIfPointIsInRectangle(rectangle, countInput);
        }

        private static void CheckIfPointIsInRectangle(Rectangle rectangle, int countInput)
        {
            for (int i = 0; i < countInput; i++)
            {
                int[] coordinatesToCheck = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int x = coordinatesToCheck[0];
                int y = coordinatesToCheck[1];

                Point pointToCheck = new Point(x, y);

                Console.WriteLine(rectangle.Contains(pointToCheck));
            }
        }
    }
}
