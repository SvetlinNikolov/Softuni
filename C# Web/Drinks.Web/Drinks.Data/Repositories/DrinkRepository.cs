using Drinks.Data.Contracts;
using Drinks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drinks.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly DrinksDbContext dbContext;

        public DrinkRepository(DrinksDbContext dbContext)
        {
            this.dbContext = dbContext;
            Console.WriteLine(dbContext.Drinks.Count());
        }
        public IEnumerable<Drink> Drinks { get; }

        public IEnumerable<Drink> PreferredDrinks { get; }

        public Drink GetDrinkById(int id)
        {
            return this.dbContext.Drinks.Find(id);
        }
    }
}
