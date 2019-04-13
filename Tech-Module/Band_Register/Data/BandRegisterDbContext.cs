using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BandRegister.Models;

namespace BandRegister.Data
{
    public class BandRegisterDbContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=BandRegisterDbContext;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
