using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Entities
{
    public class MagicCard : Card
    {
        private const int MAGIC_CARD_DEFAULT_DAMAGE_POINTS = 5;
        private const int MAGIC_CARD_DEFAULT_Health_POINTS = 80;
        public MagicCard(string name)
            : base(name, MAGIC_CARD_DEFAULT_DAMAGE_POINTS, MAGIC_CARD_DEFAULT_Health_POINTS)
        {
        }
    }
}
