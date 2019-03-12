using System;

namespace _01._Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            bool boughtLightsAndSkirts = false;
            int ornamentSet = 2;
            int treeSkirt = 5;
            int treeGarlands = 3;
            int treeLights = 15;
            int christmasSpirit = 0;
            int result = 0;

            for (int i = 1; i <= days; i++)
            {
                boughtLightsAndSkirts = false;
                if (i % 10 == 0)
                {
                    christmasSpirit -= 20;
                    result += treeGarlands + treeLights + treeSkirt;
                }
                if (i % 11 == 0)
                {
                    quantity += 2;
                }

                if (i % 2 == 0)
                {
                    result += ornamentSet * quantity;
                    christmasSpirit += 5;
                }
                if (i % 3 == 0)
                {
                    result += treeGarlands * quantity;
                    result += treeSkirt * quantity;
                    christmasSpirit += 13;
                    boughtLightsAndSkirts = true;
                }
                if (i % 5 == 0)
                {
                    result += treeLights * quantity;
                    christmasSpirit += 17;
                    if (boughtLightsAndSkirts == true)
                    {
                        christmasSpirit += 30;
                    }
                }


            }
            if (days % 10 == 0)
            {
                christmasSpirit -= 30;
            }
            Console.WriteLine($"Total cost: {result}");
            Console.WriteLine($"Total spirit: {christmasSpirit}");
        }
    }
}
