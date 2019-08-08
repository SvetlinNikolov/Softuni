using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;

            this.Targets = new List<string>();
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
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double targetHealth = Math.Abs(this.AttackPoints - target.DefensePoints);

            if (targetHealth < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints = targetHealth;
            }
            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");

            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");


            if (this.Targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine(" *Targets: " + string.Join(", ", this.Targets));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
