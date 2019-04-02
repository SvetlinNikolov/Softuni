using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string hiddenMessage = Console.ReadLine();
            // ikegfp'jpne)bv=41P83X@
            // ujfufKt)Tkmyft'duEprsfjqbvfv=53V55XA
            StringBuilder result = new StringBuilder();

            string treasurePattern = @"&([A-z]+)&";
            Regex treasure = new Regex(treasurePattern);

            string coordinatesPattern = @"<(\w+)>";
            Regex coordinates = new Regex(coordinatesPattern);


            while (true)
            {
                if (hiddenMessage == "find")
                {
                    break;
                }
                char[] hiddenMessageArray = hiddenMessage.ToCharArray();

                for (int i = 0; i < hiddenMessage.Length; i++)
                {
                    if (hiddenMessage == "find")
                    {
                        break;
                    }
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (hiddenMessageArray.Length > i)
                        {
                            if (j == numbers.Length - 1)
                            {
                                hiddenMessageArray[i] -= (char)numbers[j];
                                result.Append(hiddenMessageArray[i]);
                                j = -1;
                                i++;
                            }
                            else
                            {
                                hiddenMessageArray[i] -= (char)numbers[j];
                                result.Append(hiddenMessageArray[i]);
                                i++;
                            }
                        }
                    }

                    Match treasureMatch = treasure.Match(result.ToString());
                    Match coordinatesMatch = coordinates.Match(result.ToString());
                    result.Clear();

                    i = -1;

                    Console.WriteLine($"Found {treasureMatch.Groups[1].Value} at {coordinatesMatch.Groups[1].Value}");

                    hiddenMessage = Console.ReadLine();
                    hiddenMessageArray = hiddenMessage.ToCharArray();
                }
            }
        }
    }
}