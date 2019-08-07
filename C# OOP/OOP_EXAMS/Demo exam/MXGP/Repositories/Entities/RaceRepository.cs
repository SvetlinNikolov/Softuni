using MXGP.Models.Races.Contracts;
using MXGP.Models.Races.Entities;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories.Entities
{
    public class RaceRepository:IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Races { get => this.races; }
        public void Add(IRace model)
        {
            this.races.Add(model);
        }


        public IRace GetByName(string name)
        {
            return this.races.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races.AsReadOnly();
        }
        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }

        
    }
}
