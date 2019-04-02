using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] artistAndSong = Console.ReadLine().Split(":").ToArray();
            string nas = Console.ReadLine();
            while (true)
            {
                if (artistAndSong[0] == "end")
                {
                    break;
                }

                string namePattern = @"^([A-Z][a-z]+)[ ?])"; //TODO finish regex
                Regex name = new Regex(namePattern);

                

            }

        }
    }
}
