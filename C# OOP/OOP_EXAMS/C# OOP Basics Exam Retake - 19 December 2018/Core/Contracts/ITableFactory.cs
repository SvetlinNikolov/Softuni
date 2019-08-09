using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core.Contracts
{
    public interface ITableFactory
    {
        //        •	Type - string
        //•	TableNumber – int
        //•	Capacity - int

        ITable CreateTable(string type, int tableNumber, int capacity);
    }
}
