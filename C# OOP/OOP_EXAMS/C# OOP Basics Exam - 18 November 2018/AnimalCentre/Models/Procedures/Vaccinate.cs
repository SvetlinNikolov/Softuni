using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure, IProcedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTimeIsValid(animal, procedureTime);

            ReduceAnimalProcedureTime(animal, procedureTime);

            animal.Energy -= 8;
            animal.IsVaccinated = true;

            this.procedureHistory.Add(animal);
        }
    }
}
