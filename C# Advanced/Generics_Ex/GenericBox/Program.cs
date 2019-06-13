using System;
using System.Collections.Generic;

namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < inputLines; i++)
            {
             
                box.Add(Console.ReadLine());
            }
            Console.WriteLine(box.ToString());
        }
    }
}
