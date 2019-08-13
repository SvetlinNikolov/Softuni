using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine,IFighter
    {
        private const double INITIAL_HEALTH_POINTS = 200;
        private bool aggresiveMode;
        public bool AggressiveMode
        {
            get
            {
                return aggresiveMode;
            }
            private set
            {
                aggresiveMode = value;

                if (aggresiveMode == true)
                {
                    AttackPoints += 50;
                    DefensePoints -= 25;
                }
                else if (aggresiveMode == false)
                {
                    AttackPoints -= 50;
                    DefensePoints += 25;
                }
            }
        }


        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INITIAL_HEALTH_POINTS)
        {
            aggresiveMode = true;

        }
        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == true)
            {
                AggressiveMode = false;
            }
            else if (AggressiveMode == false)
            {
                AggressiveMode = true;
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
