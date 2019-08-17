using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.RemoveLast();

            //list.Print(Console.WriteLine);
            //Console.WriteLine(list.Count == 2);
            //Console.WriteLine(list.Contains(123));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}