using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine,ITank
    {
        private const double INITIAL_HEALTH_POINTS = 100;
        private bool defenceMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INITIAL_HEALTH_POINTS)
        {
            defenceMode = true;
        }

        public bool DefenseMode
        {
            get
            {
                return defenceMode;
            }
            private set
            {
                defenceMode = value;

                if (defenceMode == true)
                {
                    AttackPoints -= 40;
                    DefensePoints += 30;
                }
                else if (defenceMode == false)
                {
                    AttackPoints += 40;
                    DefensePoints -= 30;
                }
            }
        }

        
        public void ToggleDefenseMode()
        {
            if (DefenseMode == true)
            {
                DefenseMode = false;
            }
            else if (DefenseMode == false)
            {
                DefenseMode = true;
            }
        }

        public override string ToString()
        {

            string defenceModeCurrentValue = string.Empty;

            if (DefenseMode == true)
            {
                defenceModeCurrentValue = "ON";
            }
            else if (DefenseMode == false)
            {
                defenceModeCurrentValue = "OFF";
            }

            return base.ToString()
                + Environment.NewLine
                + $" *Defence: {defenceModeCurrentValue}";
        }

        
    }
}
