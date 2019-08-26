using System;

namespace Task
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList<int> asd = new LinkedList<int>();

            asd.AddFirst(12345);
            asd.AddLast(54321);
            
            Console.WriteLine(asd.GetSecondToLast().Value);
        }
    }
}
