using Composite.Models;
using System;

namespace Composite
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Nokia 8", 550);

            phone.CalculateTotalPrice();

            Console.WriteLine();

            var rootBox = new CompositeGift("RootBox", 0);

            var truckToy = new SingleGift("Tonka", 420);
            var plainToy = new SingleGift("Plain", 587);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            var childBox = new CompositeGift("ChildBox", 0);
            var soldierTOy = new SingleGift("Soldier", 200);

            childBox.Add(soldierTOy);

            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is {rootBox.CalculateTotalPrice()}");
        }
    }
}
