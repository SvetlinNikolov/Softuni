using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputIntegers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            ListManipulation(inputIntegers);
        }

        private static void ListManipulation(List<int> inputIntegers)
        {
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "End")
            {
                if (command[0] == "Remove")
                {

                    if (int.Parse(command[1]) >= inputIntegers.Count || int.Parse(command[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else if (int.Parse(command[1]) < inputIntegers.Count)
                    {
                        inputIntegers.RemoveAt(int.Parse(command[1]));
                    }

                }
                else if (command[0] == "Insert")
                {

                    if (int.Parse(command[2]) >= inputIntegers.Count || int.Parse(command[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else if (int.Parse(command[2]) < inputIntegers.Count)
                    {
                        inputIntegers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    }

                }
                else if (command[0] == "Add")
                {
                    inputIntegers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Shift")
                {
                    if (command[1] == "left")
                    {
                        int firstNumberOfArray = 0;
                        for (int i = 0; i < int.Parse(command[2]); i++)
                        {
                            firstNumberOfArray = inputIntegers[0];
                            inputIntegers.RemoveAt(0);
                            inputIntegers.Add(firstNumberOfArray);
                        }
                    }
                    int lastNumber = 0;
                    if (command[1] == "right")
                    {
                        for (int i = 0; i < int.Parse(command[2]); i++)
                        {
                            lastNumber = inputIntegers.Last();
                            inputIntegers.Remove(inputIntegers.Last());
                            inputIntegers.Insert(0, lastNumber);
                        }
                    }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(" ", inputIntegers));
        }
    }
}