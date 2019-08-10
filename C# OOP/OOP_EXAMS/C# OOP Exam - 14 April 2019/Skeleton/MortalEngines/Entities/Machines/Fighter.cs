using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine,IFighter
    {
        private const double INITIAL_HEALTH_POINTS = 200;

        public bool AggressiveMode { get; set; }
        //12ч

        public Fighter(string name, double attackPoints, double defensePoints)
            :base(name, attackPoints, defensePoints, INITIAL_HEALTH_POINTS)
        {
         
            this.AggressiveMode = false;
            ToggleAggressiveMode();
        }
        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == true)
            {
                AggressiveMode = false;
            }
             if (AggressiveMode == false)
            {
                AggressiveMode = true;
            }


            if (AggressiveMode == true)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else if (AggressiveMode == false)
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string aggresiveModeCurrentValue = string.Empty;

            if (AggressiveMode == true)
            {
                aggresiveModeCurrentValue = "ON";
            }
            else if (AggressiveMode == false)
            {
                aggresiveModeCurrentValue = "OFF";
            }


            return base.ToString()
                + Environment.NewLine
                + $" *Aggresive: {aggresiveModeCurrentValue}";
        }
    }
}
