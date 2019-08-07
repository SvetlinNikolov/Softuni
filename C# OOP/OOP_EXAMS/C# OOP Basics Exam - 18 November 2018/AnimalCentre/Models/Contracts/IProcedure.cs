using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        IList<IAnimal> ProcedureHistory { get; }
        string History();

        void DoService(IAnimal animal, int procedureTime);

    }
}
