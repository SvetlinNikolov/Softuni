using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IMachine,IFighter
    {
        private const double INITIAL_HP = 200;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INITIAL_HP)
        {
            ToggleAggressiveMode();

        }

        public bool AggressiveMode { get; private set; }
        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= 50;
                this.DefensePoints += 25;

            }
            else if (this.AggressiveMode == false)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;

                this.AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            string aggresiveModeStatus = string.Empty;

            if (this.AggressiveMode == true)
            {
                aggresiveModeStatus = " *Aggressive: ON";
            }
            else if (this.AggressiveMode == false)
            {
                aggresiveModeStatus = " *Aggressive: OFF";
            }

            //Maybe has to be on same line 
            return base.ToString()
                +Environment.NewLine
                + aggresiveModeStatus
                .TrimEnd();
        }
    }
}
