using Drinks.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks.Data
{
    public class DrinksDbContext : DbContext
    {
        public DrinksDbContext()
        {

        }
        public DrinksDbContext(DbContextOptions<DrinksDbContext> options)
            : base(options)
        {

        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
