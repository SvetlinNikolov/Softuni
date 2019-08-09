﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Contracts.Entities
{
    public class OutsideTable : Table, ITable
    {
        private const decimal InitialPricePerPerson = 3.50m;
        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}
