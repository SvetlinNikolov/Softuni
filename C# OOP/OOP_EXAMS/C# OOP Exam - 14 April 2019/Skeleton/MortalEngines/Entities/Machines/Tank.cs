using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine,ITank
    {
        private const double INITIAL_HEALTH_POINTS = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INITIAL_HEALTH_POINTS)
        {
           
            this.DefenseMode = false;
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; set; }


        public void ToggleDefenseMode()
        {
            if (DefenseMode == true)
            {
                DefenseMode = false;
            }
            if (DefenseMode == false)
            {
                DefenseMode = true;
            }
        }

        public override string ToString()
        {

            string defenceModeCurrentValue = string.Empty;


            if (DefenseMode == true)
            {
                AttackPoints -= 40;
                DefensePoints += 30;
            }
            if (DefenseMode == false)
            {
                AttackPoints += 40;
                DefensePoints -= 30;
            }

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
