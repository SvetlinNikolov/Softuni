using MXGP.Models.Riders.Contracts;
using MXGP.Models.Riders.Entities;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories.Entities
{
    public class RiderRepository:IRepository<IRider>
    {
        private List<IRider> riders;

        public RiderRepository()
        {
            riders = new List<IRider>();
        }

        public IReadOnlyCollection<IRider> Riders { get => this.riders; }
        public void Add(IRider model)
        {
            this.riders.Add(model);
        }


        public IRider GetByName(string name)
        {
            return this.riders.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders.AsReadOnly();
        }
        public bool Remove(IRider model)
        {
            return this.riders.Remove(model);
        }
    }
}
