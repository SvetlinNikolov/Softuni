
using System;

namespace _04._Hotel_Reservation
{

    public class PriceCalculator
    {

        public static decimal CalculatePrice(decimal pricePerDay,
        int numberOfDays, Season season, Discount discount)
        {
            decimal multipliedPricePerDay = pricePerDay * (int)season;
            double discountPercent = (double)discount;

            decimal priceWithoutDiscount = numberOfDays * multipliedPricePerDay;

            decimal priceWithDiscount = priceWithoutDiscount - (priceWithoutDiscount * (decimal)discountPercent/100);

            return Math.Round(priceWithDiscount, 2);
        }

    }


}

