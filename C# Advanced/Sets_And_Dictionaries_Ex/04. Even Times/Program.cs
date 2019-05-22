
namespace _04._Even_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < countNumbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(currentNumber))
                {
                    dict[currentNumber] = new List<int>();
                    dict[currentNumber].Add(currentNumber);
                }
                else if (dict.ContainsKey(currentNumber))
                {
                    dict[currentNumber].Add(currentNumber);
                }
            }
            foreach (var kvp in dict)
            {
                if (kvp.Value.Count % 2 == 0)
                {
                    Console.WriteLine(kvp.Value[0]);
                    break;
                }
            }
        }
    }
}
