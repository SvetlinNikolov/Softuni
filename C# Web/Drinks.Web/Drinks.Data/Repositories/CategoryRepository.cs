using Drinks.Data.Contracts;
using Drinks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DrinksDbContext dbContext;

        public CategoryRepository(DrinksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Category> Categories { get; }
    }
}
