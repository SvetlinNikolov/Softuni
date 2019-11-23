using System;

namespace Design_Patterns_Ex
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("White", "Bacon", "", "Letuce, Tomato");

            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Letuce, Tomato, Onion, Olives");

            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
        }
    }
}
