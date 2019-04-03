using System;

namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int companions = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            bool motivationalDay = false;
            int coins = 0;

            for (int currentDays = 1; currentDays <= days; currentDays++)
            {
                if (currentDays % 10 == 0)
                {
                    companions -= 2;
                }
                if (currentDays % 15 == 0)
                {
                    companions += 5;
                }

                coins += 50;
                coins = coins - (companions * 2);

                if (currentDays % 3 == 0)
                {
                    coins = coins - (companions * 3);
                    motivationalDay = true;
                }
                if (currentDays % 5 == 0 && motivationalDay == false)
                {
                    coins = coins + (companions * 20);
                }
                else if (currentDays % 5 == 0 && motivationalDay == true)
                {
                    coins = coins + (companions * 20);
                    coins = coins - (companions * 2);
                }

                motivationalDay = false;
            }
            Console.WriteLine($"{companions} companions received {coins / companions} coins each.");
        }
    }
}

