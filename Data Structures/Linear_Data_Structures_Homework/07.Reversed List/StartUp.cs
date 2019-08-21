using System;

namespace ReverseList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ReversedList<int> john = new ReversedList<int>();

            john.Add(1);
            john.Add(3);
            john.Add(123);

            john.RemoveAt(0);
            Console.WriteLine(john[0] + " " + john[1]);
        }
    }
}
