using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> saladCollection;

        public string Name { get; set; }

        public Salad(string name)
        {
            this.Name = name;
            saladCollection = new List<Vegetable>();
        }
        public int GetTotalCalories()
        {
            int totalCalories = 0;

            foreach (var vegetable in saladCollection)
            {
                totalCalories += vegetable.Calories;
            }
            return totalCalories;
        }

        public int GetProductCount()
        {
            return saladCollection.Count;
        }

        public void Add(Vegetable vegetable)
        {
            saladCollection.Add(vegetable);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string saladInformation =$"* Salad {Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:";

            sb.AppendLine(saladInformation);

            foreach (var vegetable in saladCollection)
            {
                sb.AppendLine(vegetable.ToString());
            }

            return sb.ToString();
           

        }
    }
}
