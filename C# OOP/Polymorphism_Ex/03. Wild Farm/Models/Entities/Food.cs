using _03._Wild_Farm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Models.Entities
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; }
    }
}
