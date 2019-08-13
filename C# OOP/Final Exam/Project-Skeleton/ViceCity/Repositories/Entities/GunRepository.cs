using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories.Entities
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();
        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public void Add(IGun model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }
    }
}
