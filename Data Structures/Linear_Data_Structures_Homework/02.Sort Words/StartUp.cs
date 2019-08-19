using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sort_Words
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                   .Split()
                   .ToList();

            Console.WriteLine(string.Join(" ",words.OrderBy(x=>x)));
        }
    }
}
