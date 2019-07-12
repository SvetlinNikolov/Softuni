using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Telephony
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            SmartPhone smartPhone = new SmartPhone();

            string[] numbers = Console.ReadLine()
                .Split(" ");


            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(smartPhone.Call(number));
                }
                catch (Exception ine)
                {
                    Console.WriteLine(ine.Message);
                    continue;
                }

            }

            string[] urls = Console.ReadLine()
                .Split(" ");

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(url));
                }
                catch (Exception iue)
                {
                    Console.WriteLine(iue.Message);
                    continue;
                }

            }
        }
    }
}
