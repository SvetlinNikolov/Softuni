﻿using System;
using System.Collections.Generic;
namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            //box.Add("123");
            //box.Add(2);
            //box.Add(3);
            //Console.WriteLine(box.Remove());
            //box.Add(4);
            //box.Add(5);
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Count);
        }
    }
}
