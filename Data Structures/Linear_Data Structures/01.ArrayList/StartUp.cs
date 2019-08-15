using System;

namespace _01.ArrayList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ArrayList<int> list = new ArrayList<int>();

            list.Add(5);
            list[0] = list[0] + 1;

            Console.WriteLine(list[0]);
        }
    }
}
