using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }
        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetWeaponPower()
        {
            int sumOfWeaponProps = this.Weapon.Sharpness
                + this.Weapon.Size
                + this.Weapon.Solidity;

            return sumOfWeaponProps;
        }
        public int GetStatPower()
        {
            int sumOfStatProps = this.Stat.Agility
                + this.Stat.Intelligence
                + this.Stat.Skills
                + this.Stat.Strength
                +this.Stat.Flexibility;

            return sumOfStatProps;
        }

        public int GetTotalPower()
        {
            int sumOfStatAndWeaponProps = GetStatPower() + GetWeaponPower();

            return sumOfStatAndWeaponProps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: [{GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{GetStatPower()}]");

            return sb.ToString().TrimEnd();
        }
    }
}
