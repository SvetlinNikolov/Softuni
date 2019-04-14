using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regexPattern = @"(^[!@#$?A-z0-9!@#$?]+)=([0-9]+)<<(.+)";
            Regex fullRegex = new Regex(regexPattern);

            string nameOfmountain = string.Empty;

            while (input != "Last note")
            {
                if (fullRegex.IsMatch(input))
                {
                    Match match = fullRegex.Match(input);

                    string[] coordinates = input.Split("<<").ToArray();
                    string[] mountainNameArray = input.Split("=").ToArray();
                    string mountainName = mountainNameArray[0];

                    int coordinatesLenght = coordinates.Last().Length;
                    string coordinatesOfMountain = coordinates.Last();

                    int lenghtOfMountainGroupInRegex = int.Parse(match.Groups[2].Value);

                    if (coordinatesLenght == lenghtOfMountainGroupInRegex)
                    {
                        foreach (var symbol in mountainName)
                        {
                            if (char.IsLetterOrDigit(symbol))
                            {
                                nameOfmountain += symbol;
                            }
                        }
                        Console.WriteLine($"Coordinates found! { nameOfmountain} -> { coordinatesOfMountain}");
                        nameOfmountain = string.Empty;
                        input = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        input = Console.ReadLine();
                        nameOfmountain = string.Empty;
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                    input = Console.ReadLine();
                    nameOfmountain = string.Empty;
                }
            }
        }
    }
}