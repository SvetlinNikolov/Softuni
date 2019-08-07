using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure, IProcedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTimeIsValid(animal, procedureTime);

            ReduceAnimalProcedureTime(animal, procedureTime);

            animal.Happiness -= 7;

            this.procedureHistory.Add(animal);
        }
    }
}
