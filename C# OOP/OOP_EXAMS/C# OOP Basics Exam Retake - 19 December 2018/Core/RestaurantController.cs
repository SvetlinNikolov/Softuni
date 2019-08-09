namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Core.Contracts;
    using SoftUniRestaurant.Core.Factories;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private IList<ITable> tables;
        private IList<IFood> menu;
        private IList<IDrink> drinks;
        private IFoodFactory foodFactory;
        private IDrinkFactory drinkFactory;
        private ITableFactory tableFactory;
        private decimal totalSumOfOrders;

        public RestaurantController(
             )
        {
            tables = new List<ITable>();
            menu = new List<IFood>();
            drinks = new List<IDrink>();
            foodFactory = new FoodFactory();
            drinkFactory = new DrinkFactory();
            tableFactory = new TableFactory();
        }
        public string AddFood(string type, string name, decimal price)
        {
            IFood createdFood = foodFactory.CreateFood(type, name, price);

            
            this.menu.Add(createdFood);
            return $"Added {createdFood.Name} ({createdFood.GetType().Name}) with price {createdFood.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drinkToCreate = drinkFactory.CreatedDrink(type, name, servingSize, brand);
            this.drinks.Add(drinkToCreate);
            return $"Added {drinkToCreate.Name} ({drinkToCreate.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable tableToCreate = tableFactory.CreateTable(type, tableNumber, capacity);
            this.tables.Add(tableToCreate);
            return $"Added table number {tableToCreate.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = this.tables
                .FirstOrDefault(x => x.IsReserved == false
                && x.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            freeTable.Reserve(numberOfPeople);
            return $"Table {freeTable.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var food = this.menu.FirstOrDefault(x => x.Name == foodName);

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {table.TableNumber} ordered {food.Name}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            var tableBill = table.GetBill();

            totalSumOfOrders += tableBill;

            table.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {tableBill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            //Maybe more manipulation needed here on foreach
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var occupiedtable in this.tables.Where(x => x.IsReserved == true))
            {
                sb.AppendLine(occupiedtable.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            //Maybe dont need tables sum
            


            return $"Total income: {totalSumOfOrders:f2}lv";
        }
    }
}
