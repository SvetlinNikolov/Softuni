using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure, IProcedure
    {

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{ animal.Name } is already chipped");
            }

            CheckProcedureTimeIsValid( animal,  procedureTime);

            animal.IsChipped = true;
            animal.Happiness -= 5;
           
            this.procedureHistory.Add(animal);
        }
    }
}
