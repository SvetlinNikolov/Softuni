using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;


        private const string OWNER = "Centre";
        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

            this.Owner = OWNER;
        }

        public string Name { get; }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
             set
            {
                ValidateValueRange(value, "Invalid happiness");
                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
             set
            {
                ValidateValueRange(value, "Invalid energy");
                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get;  set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }

       
        private static void ValidateValueRange(int value, string message)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
