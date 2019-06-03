
namespace _01._Action_Point
{
    using System;

    class StartUp
    {

        static void Main(string[] args)
        {

            string[] names = Console.ReadLine()
                 .Split(new char[] { ' ' },
                 StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = currentName =>
              Console.WriteLine(currentName);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
