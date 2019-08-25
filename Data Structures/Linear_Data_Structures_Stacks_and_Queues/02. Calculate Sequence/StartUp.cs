using System;
using System.Collections.Generic;

namespace _02._Calculate_Sequence
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> sequence = new Queue<int>();

            int n = int.Parse(Console.ReadLine());
            int index = 0;
            sequence.Enqueue(n);

            int[] result = new int[50];

            while (true)
            {
                int element = sequence.Dequeue();
                result[index] = element;
                index++;

                if (index == 50)
                {
                    break;
                }

                sequence.Enqueue(element + 1);
                sequence.Enqueue(2 * element + 1);
                sequence.Enqueue(element + 2);

            }

            Console.WriteLine(string.Join(", ", result));

        }
    }
}
