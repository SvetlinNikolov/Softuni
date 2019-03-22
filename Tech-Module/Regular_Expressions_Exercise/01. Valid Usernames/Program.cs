using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ").ToArray();

            string regex = @"\b^[A-z][\w-]{3,15}$\b";

            Regex regexUsernames = new Regex(regex);
            foreach (var username in usernames)
            {
                if (regexUsernames.IsMatch(username))
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}
