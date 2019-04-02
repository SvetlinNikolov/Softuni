using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> morseCodeInput = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string morseCodeToString = string.Empty;

            foreach (var letter in morseCodeInput)
            {
                morseCodeToString += letter;
            }

            List<string> lettersOfMorseCode = morseCodeToString.Split().ToList();

            ConvertToMorseCode(lettersOfMorseCode);
        }

        private static void ConvertToMorseCode(List<string> lettersOfMorseCode)
        {
            foreach (var letter in lettersOfMorseCode)
            {
                switch (letter)
                {
                    case "":
                        Console.Write(" ");
                        break;
                    case ".-":
                        Console.Write("A");
                        break;
                    case "-...":
                        Console.Write("B");
                        break;
                    case "-.-.":
                        Console.Write("C");
                        break;
                    case "-..":
                        Console.Write("D");
                        break;
                    case ".":
                        Console.Write("E");
                        break;
                    case "..-.":
                        Console.Write("F");
                        break;
                    case "--.":
                        Console.Write("G");
                        break;
                    case "....":
                        Console.Write("H");
                        break;
                    case "..":
                        Console.Write("I");
                        break;
                    case ".---":
                        Console.Write("J");
                        break;
                    case "-.-":
                        Console.Write("K");
                        break;
                    case ".-..":
                        Console.Write("L");
                        break;
                    case "--":
                        Console.Write("M");
                        break;
                    case "-.":
                        Console.Write("N");
                        break;
                    case "---":
                        Console.Write("O");
                        break;
                    case ".--.":
                        Console.Write("P");
                        break;
                    case "--.-":
                        Console.Write("Q");
                        break;
                    case ".-.":
                        Console.Write("R");
                        break;
                    case "...":
                        Console.Write("S");
                        break;
                    case "-":
                        Console.Write("T");
                        break;
                    case "..-":
                        Console.Write("U");
                        break;
                    case "...-":
                        Console.Write("V");
                        break;
                    case ".--":
                        Console.Write("W");
                        break;
                    case "-..-":
                        Console.Write("X");
                        break;
                    case "-.--":
                        Console.Write("Y");
                        break;
                    case "--..":
                        Console.Write("Z");
                        break;
                }
            }
        }
    }
}
