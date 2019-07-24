using System;

namespace Fixing
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[5];

            weekDays[0] = "Sunday";
            weekDays[1] = "Monday";
            weekDays[2] = "Tuesday";
            weekDays[3] = "Wednesday";
            weekDays[4] = "Thursday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekDays[i].ToString());
                }
            }
            catch (IndexOutOfRangeException io)
            {

                throw new IndexOutOfRangeException(io.Message,io);
            }

            Console.ReadLine();
        }

    }
}
