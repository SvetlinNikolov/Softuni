using System;
using System.Linq;

namespace Default
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] fieldArray = new int[fieldSize];

            int[] ladybugs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < ladybugs.Length; i++)
            {

                for (int j = 0; j < fieldArray.Length; j++)
                {
                    fieldArray[ladybugs[i]] = 1;
                }
            }
            string[] command = new string[3];
             

            while (command[0] != "end")
            {
                command = Console.ReadLine()
                .Split()
                .ToArray();

                if (command[0]== "end")
                {
                    break;
                }

                int chosenBug = int.Parse(command[0]);
                int moveBug = int.Parse(command[2]);

                if (fieldArray[chosenBug] == 1)
                {
                    if (command[1] == "right")
                    {
                        if (fieldArray[moveBug] == 0)
                        {
                            fieldArray[moveBug] = 1;
                            fieldArray[chosenBug] = 0;
                        }
                        else if (fieldArray[moveBug] == 1)
                        {
                            for (int i = fieldArray[moveBug]; i < fieldArray.Length; i++)
                            {
                                if (fieldArray[moveBug + 1] == 0)
                                {
                                    fieldArray[moveBug] = 1;
                                    fieldArray[chosenBug] = 0;
                                    break;
                                }
                                else if (fieldArray[moveBug + 1] == 1)
                                {

                                }
                            }
                        }
                    }
                }
               
            }
        }
    }
}