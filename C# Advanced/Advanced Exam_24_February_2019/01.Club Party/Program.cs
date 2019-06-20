using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split(" ");

            Stack<string> collection = new Stack<string>(input);
            Queue<char> hallNames = new Queue<char>();

            StringBuilder sb = new StringBuilder();

            int hallMinusPeople = hallCapacity;

            while (true)
            {
                if (collection.Count == 0)
                {
                    break;
                }
                bool isNumber = int.TryParse(collection.Peek(), out int peopleCount);

                if (isNumber && hallNames.Count == 0)
                {
                    collection.Pop();
                    continue;
                }

                if (isNumber == false)
                {
                    char currentHallName = char.Parse(collection.Pop());
                    hallNames.Enqueue(currentHallName);
                    continue;
                }

                if (hallNames.Count > 0)
                {

                    hallMinusPeople -= peopleCount;

                    if (hallMinusPeople >= 0)
                    {
                        sb.Append(peopleCount + ", ");
                        collection.Pop();
                        continue;

                    }
                    else
                    {
                        Console.Write(hallNames.Dequeue() + " -> ");
                        Console.WriteLine(sb.ToString().Trim(',', ' '));
                        sb.Clear();

                        hallMinusPeople = hallCapacity;
                    }
                }
            }
        }
    }
}
