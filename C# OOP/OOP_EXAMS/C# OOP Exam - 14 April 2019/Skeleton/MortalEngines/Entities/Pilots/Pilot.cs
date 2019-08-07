﻿using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Pilots
{
    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            machines = new List<IMachine>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<IMachine> Machines =>this.machines.AsReadOnly();

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.Machines.Count} machines");

            foreach (var machine in Machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
