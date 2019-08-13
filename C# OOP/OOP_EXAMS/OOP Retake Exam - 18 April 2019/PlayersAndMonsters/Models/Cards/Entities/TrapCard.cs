using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Entities
{
    public class TrapCard : Card
    {
        private const int TRAP_CARD_DEFAULT_DAMAGE_POINTS = 120;
        private const int TRAP_CARD_DEFAULT_Health_POINTS = 5;
        public TrapCard(string name) 
            : base(name, TRAP_CARD_DEFAULT_DAMAGE_POINTS, TRAP_CARD_DEFAULT_Health_POINTS)
        {
        }
    }
}
