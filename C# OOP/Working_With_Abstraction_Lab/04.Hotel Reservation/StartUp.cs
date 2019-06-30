using System;

namespace _04._Hotel_Reservation
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            string[] resertvationInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(resertvationInfo[0]);
            int numberOfDays = int.Parse(resertvationInfo[1]);
            string season = resertvationInfo[2];
            string discountType = "None";

            if (resertvationInfo.Length == 4)
            {
                discountType = resertvationInfo[3];
            }

            Console.WriteLine(PriceCalculator.CalculatePrice(pricePerDay, numberOfDays,
                Enum.Parse<Season>(season), Enum.Parse<Discount>(discountType)));




        }

    }
}

