using SoftUniRestaurant.Core.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core.Factories
{
    public class TableFactory : ITableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            ITable tableToReturn = null;

            switch (type.ToLower())
            {
                case "inside":
                    tableToReturn = new InsideTable(tableNumber, capacity);
                    break;
                case "outside":
                    tableToReturn = new OutsideTable(tableNumber, capacity);
                    break;
            }

            return tableToReturn;
        }
    }
}
