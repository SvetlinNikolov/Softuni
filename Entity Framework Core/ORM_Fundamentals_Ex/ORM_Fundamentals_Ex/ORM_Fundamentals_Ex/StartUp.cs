using System;
using System.Collections.Generic;

namespace ORM_Fundamentals_Ex
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();

            cat.Age = 5;

            List<Cat> asd = new List<Cat>();
            int nig = 5;

            List<int> ints = new List<int>();
            List<string> strings = new List<string>();

            string asdf = "asd bby";

            strings.Add(asdf);

            strings[0] = "stabadelic bby";

            Console.WriteLine(asdf);

            ints.Add(nig);

            ints[0] = 125;

            Console.WriteLine(nig);

            void Test(int a)
            {
                a = 100;
            }

            Test(nig);

            Console.WriteLine(nig);


        }

    }
}
