using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Cards.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories.Entities
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard cardToCreate = null;

            if (type.ToLower() == "magic".ToLower())
            {
                cardToCreate = new MagicCard(name);
            }
            else if (type.ToLower() == "trap".ToLower())
            {
                cardToCreate = new TrapCard(name);
            }

            return cardToCreate;
        }
    }
}
