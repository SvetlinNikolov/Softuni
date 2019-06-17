using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> saladData;

        public string Name { get; set; }

        public Restaurant(string name)
        {
            this.Name = name;
            saladData = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            saladData.Add(salad);
        }


        public bool Buy(string name)
        {
            if (saladData.Exists(x => x.Name == name))
            {
                Salad saladToRemove = saladData.Where(x => x.Name == name).ToList()[0];
                saladData.Remove(saladToRemove);
                return true;
            }
            
            return false;
        }

        public string GetHealthiestSalad()
        {
            Salad healthiestSalad = new Salad("shhh");

            foreach (var salad in saladData)
            {
                if (healthiestSalad.GetTotalCalories() == 0)
                {
                    healthiestSalad = salad;
                }
                if (salad.GetTotalCalories() < healthiestSalad.GetTotalCalories())
                {
                    healthiestSalad = salad;
                }
            }
            return healthiestSalad.Name;

        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            string saladInfo = $"{Name} have {saladData.Count} salads:";

            sb.AppendLine(saladInfo);

            foreach (var salad in saladData)
            {
                sb.AppendLine(salad.ToString());
            }

            return sb.ToString();
        }
    }
}
