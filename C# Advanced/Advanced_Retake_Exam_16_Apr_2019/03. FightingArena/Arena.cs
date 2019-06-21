using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;
        public Arena(string name)
        {
            this.Name = name;
            gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count => gladiators.Count();
        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }
        public void Remove(string name)
        {
            Gladiator gladiatorToRemove = gladiators.FirstOrDefault(x => x.Name == name);
            gladiators.Remove(gladiatorToRemove);
        }
        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladitorWithHighestStatPower =
                gladiators.OrderByDescending(x => x.GetStatPower()).ToList()[0];

            return gladitorWithHighestStatPower;
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator gladitorWithHighestWeaponPower =
                gladiators.OrderByDescending(x => x.GetWeaponPower()).ToList()[0];

            return gladitorWithHighestWeaponPower;
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladitorWithHighestTotalPower =
                gladiators.OrderByDescending(x => x.GetTotalPower()).ToList()[0];

            return gladitorWithHighestTotalPower;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{Name}] - [{Count}] gladiators are participating.");

            return sb.ToString().TrimEnd();
        }
    }
}
