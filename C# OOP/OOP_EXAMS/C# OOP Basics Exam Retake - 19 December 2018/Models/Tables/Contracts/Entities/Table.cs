using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Contracts.Entities
{
    public abstract class Table : ITable
    {
        private readonly List<IFood> FoodOrders;
        private readonly List<IDrink> DrinkOrders;

        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            FoodOrders = new List<IFood>();
            DrinkOrders = new List<IDrink>();
        }
        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.numberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            //I AM WORKING WITH THE FIELD HERE!!! COULD BE AN ERROR
            //Removes all of the ordered drinks and food and
            //finally frees the table and sets the count of people to 0.

            this.FoodOrders.Clear();
            this.DrinkOrders.Clear();

            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal totalSumOfItems = this.FoodOrders.Sum(x => x.Price)
                + this.DrinkOrders.Sum(x => x.Price)
                +this.Price;

            return totalSumOfItems;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}")
           .AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Capacity: {this.Capacity}")
            .AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();

        }

        public string GetOccupiedTableInfo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}")
           .AppendLine($"Type: {this.GetType().Name}")
           .AppendLine($"Number of people: {this.NumberOfPeople}");

            if (FoodOrders.Count == 0)
            {
                sb.AppendLine($"Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.FoodOrders.Count}");

                foreach (var food in this.FoodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }

            if (DrinkOrders.Count == 0)
            {
                sb.AppendLine($"Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.DrinkOrders.Count}");

                foreach (var drink in this.DrinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().TrimEnd();

        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
