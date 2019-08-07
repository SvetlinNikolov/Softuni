using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure, IProcedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTimeIsValid(animal, procedureTime);

            ReduceAnimalProcedureTime(animal, procedureTime);

            animal.Energy -= 6;
            animal.Happiness += 12;

            this.procedureHistory.Add(animal);
        }
    }
}
