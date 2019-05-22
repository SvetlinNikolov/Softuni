

namespace _03._Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            int countElements = int.Parse(Console.ReadLine());

            HashSet<string> uniqueElements = new HashSet<string>();

            for (int i = 0; i < countElements; i++)
            {
                string[] periodicTableElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in periodicTableElements)
                {
                    uniqueElements.Add(element);
                }
                    
            }
            Console.WriteLine(string.Join(" ",uniqueElements.OrderBy(x=>x)));
        }
    }
}
