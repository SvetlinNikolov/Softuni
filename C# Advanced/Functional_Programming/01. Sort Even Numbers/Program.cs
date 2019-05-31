﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .Where(x => x % 2 == 0)
                   .OrderBy(x => x)
                   .ToList();

            Console.WriteLine( string.Join(", ", numbers) ); 





        }
    }
}
