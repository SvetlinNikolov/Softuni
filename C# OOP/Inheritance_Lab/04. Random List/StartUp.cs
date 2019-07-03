using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("10");
            randomList.Add("20");
            randomList.Add("30");
            randomList.Add("40");
            randomList.Add("50");
            randomList.Add("60");
            Console.WriteLine(randomList.RandomString()); 
        }
    }
}
