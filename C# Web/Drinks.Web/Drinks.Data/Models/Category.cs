using System.Collections;
using System.Collections.Generic;

namespace Drinks.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Drink> Drinks { get; set; } = new HashSet<Drink>();
    }
}