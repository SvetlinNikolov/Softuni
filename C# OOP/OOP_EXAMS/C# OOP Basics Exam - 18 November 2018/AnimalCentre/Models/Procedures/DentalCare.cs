using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure,IProcedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTimeIsValid(animal, procedureTime);

            ReduceAnimalProcedureTime(animal, procedureTime);

            animal.Happiness += 12;
            animal.Energy += 10;
           
            this.procedureHistory.Add(animal);
        }
    }
}
