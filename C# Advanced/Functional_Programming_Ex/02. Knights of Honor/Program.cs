using System;
using System.Linq;
namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, string> addSir = x => "Sir " + x;

            Action<string[]> addSirInfront = x =>
            Console.WriteLine(string.Join(Environment.NewLine, x.Select(addSir)));

            addSirInfront(names);

        }
    }
}
