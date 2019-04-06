using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> encryptedMessage = Console.ReadLine().ToList();

            string encToString = string.Empty;

            foreach (var letter in encryptedMessage)
            {
                encToString += letter;
            }

            string pattern = @"^([d-z\{\},#|]+)$";
            Regex validMessage = new Regex(pattern);

            string[] letterOrSubstring = Console.ReadLine().Split().ToArray();

            StringBuilder sb = new StringBuilder();

            if (!validMessage.IsMatch(encToString))
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }

            for (int i = 0; i < encryptedMessage.Count; i++)
            {
                encryptedMessage[i] -= (char)3;
                sb.Append(encryptedMessage[i]);
            }
            sb.Replace(letterOrSubstring[0], letterOrSubstring[1]);

            Console.WriteLine(sb);
            //wkhfn#|rx#jhqfkr#phf#exw#|rxu#uholf#lv#khfgohg#lq#hfrwkhu#sohfhw
        }
    }
}
