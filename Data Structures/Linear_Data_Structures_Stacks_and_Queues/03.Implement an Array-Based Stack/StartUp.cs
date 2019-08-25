using System;

namespace _03.Implement_an_Array_Based_Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ArrayStack<int> stack = new ArrayStack<int>();

            for (int i = 0; i < 100; i++)
            {
                stack.Push(420);
            }
            for (int i = 0; i < 99; i++)
            {
                stack.Pop();
            }
            ;
        }
    }
}
