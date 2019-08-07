
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Motorcycles.Entities;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories.Entities
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }

       
        public void Add(IMotorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public IMotorcycle GetByName(string name)
        {
            return this.motorcycles.FirstOrDefault(x => x.Model == name);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motorcycles.ToList();
        }
        public bool Remove(IMotorcycle model)
        {
            return this.motorcycles.Remove(model);
        }

        
    }
}
