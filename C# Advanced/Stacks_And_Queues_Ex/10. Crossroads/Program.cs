using System;
using System.Collections.Generic;

namespace crossRoads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());

            int freeWindows = int.Parse(Console.ReadLine());

            Queue<string> carQueue = new Queue<string>();
            Queue<string> carsInCrossroad = new Queue<string>();

            int carsThatPassed = 0;
            int greenDuration = 0;

            while (true)
            {
                greenDuration = greenLightDuration;

                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                if (input != "green")
                {
                    carQueue.Enqueue(input);
                }
                while (carQueue.Count > 0 && input == "green")
                {
                   
                    if (greenDuration > 0)
                    {
                        string currentCar = carQueue.Dequeue();

                        if (greenDuration - currentCar.Length > 0)
                        {
                            greenDuration -= currentCar.Length;
                            carsThatPassed++;
                        }
                        else if (greenDuration - currentCar.Length <= 0)
                        {
                            int windows = greenDuration + freeWindows;

                            if (windows- currentCar.Length < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[windows]}.");
                                return;
                            }
                            else
                            {
                                greenDuration -= currentCar.Length;
                                carsThatPassed++;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                 
                }
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{carsThatPassed} total cars passed the crossroads.");
        }
    }
}
