﻿using System;
using Template.Models;

namespace Template
{
   public class Program
    {
        static void Main(string[] args)
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
              
        }
    }
}