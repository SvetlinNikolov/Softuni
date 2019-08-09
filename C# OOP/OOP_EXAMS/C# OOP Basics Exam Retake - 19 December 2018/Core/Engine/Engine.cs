using SoftUniRestaurant.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core.Engine
{
    public class Engine : IEngine
    {
        private RestaurantController restaurantController;
        public Engine()
        {
            restaurantController = new RestaurantController();
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] tokens = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (tokens[0] == "END")
                    {
                        Console.WriteLine(restaurantController.GetSummary());  
                        break;
                    }

                    switch (tokens[0].ToLower())
                    {
                        case "addfood":
                            Console.WriteLine(restaurantController.AddFood(tokens[1], tokens[2], decimal.Parse(tokens[3])));    
                            break;
                        case "adddrink":
                            Console.WriteLine(restaurantController.AddDrink(tokens[1], tokens[2], int.Parse(tokens[3]), tokens[4]));   
                            break;
                        case "addtable":
                            Console.WriteLine(restaurantController.AddTable(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]))); 
                            break;
                        case "reservetable":
                            Console.WriteLine(restaurantController.ReserveTable(int.Parse(tokens[1]))); 
                            break;
                        case "orderfood":
                            Console.WriteLine(restaurantController.OrderFood(int.Parse(tokens[1]), tokens[2])); 
                            break;
                        case "orderdrink":
                            Console.WriteLine(restaurantController.OrderDrink(int.Parse(tokens[1]), tokens[2], tokens[3]));  
                            break;
                        case "leavetable":
                            Console.WriteLine(restaurantController.LeaveTable(int.Parse(tokens[1])));  
                            break;
                        case "getfreetablesinfo":
                            Console.WriteLine(restaurantController.GetFreeTablesInfo()); 
                            break;
                        case "getoccupiedtablesinfo":
                            Console.WriteLine(restaurantController.GetOccupiedTablesInfo()); 
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
