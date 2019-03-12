using System;
using System.Collections.Generic;
using System.Linq;
namespace Retake_Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldCount = int.Parse(Console.ReadLine());
            int[] field = new int[fieldCount];

            int[] ladybugPostitionOnField = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < ladybugPostitionOnField.Length; i++)
            {
                field[ladybugPostitionOnField[i]] = 1;
            }

            string[] commands = Console.ReadLine().Split().ToArray();
            while (commands[0] != "end")
            {
                int chosenLadyBug = int.Parse(commands[0]);
                string leftOrRight = commands[1];
                int spacesToMoveLadyBug = int.Parse(commands[2]);

                int indexToMoveBug = field[chosenLadyBug] + spacesToMoveLadyBug;

                if (leftOrRight == "right")
                {
                    if (indexToMoveBug < field.Length)  
                    {
                        if (field[indexToMoveBug] == 0)
                        {
                            field[chosenLadyBug] = 0;
                            field[spacesToMoveLadyBug] = 1;
                        }
                    }
                }
            }
        }
    }
}
