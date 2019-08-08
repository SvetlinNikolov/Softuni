using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HP = 100;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INITIAL_HP)
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {

            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;

                this.AttackPoints += 40;
                this.DefensePoints -= 30;

            }
            else if (this.DefenseMode == false)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;

                this.DefenseMode = true;
            }
        }
        public override string ToString()
        {
            string defenseModeStatus = string.Empty;

            if (this.DefenseMode == true)
            {
                defenseModeStatus = " *Defense: ON";
            }
            else if (this.DefenseMode == false)
            {
                defenseModeStatus = " *Defense: OFF";
            }

            //Maybe has to be on same line 
            return base.ToString()
                +Environment.NewLine
                + defenseModeStatus
                .TrimEnd();
        }
    }
}
