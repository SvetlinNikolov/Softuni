using System;

namespace _04.LinkedStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            LinkedStack<int> ss = new LinkedStack<int>();

            ss.Push(2);
            ss.Push(13);
            Console.WriteLine(ss.Pop()); 
        }
    }
}
