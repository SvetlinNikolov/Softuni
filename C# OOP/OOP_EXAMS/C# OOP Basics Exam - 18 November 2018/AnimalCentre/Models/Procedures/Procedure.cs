using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;
        public IList<IAnimal> ProcedureHistory => procedureHistory.AsReadOnly();


        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var Ianimal in ProcedureHistory)
            {
                sb.AppendLine($"{Ianimal.GetType().Name}");
                sb.AppendLine($" - {Ianimal.Name} - Happiness: { Ianimal.Happiness} - Energy: { Ianimal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        public void CheckProcedureTimeIsValid(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        public void ReduceAnimalProcedureTime(IAnimal animal, int procedureTime)
        {
            animal.ProcedureTime -= procedureTime;
        }
    }
}
