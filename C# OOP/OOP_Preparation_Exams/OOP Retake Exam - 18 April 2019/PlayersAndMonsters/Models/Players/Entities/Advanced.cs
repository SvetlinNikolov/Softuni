using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Entities
{
    public class Advanced : Player
    {
        public const int ADVANCED_PLAYER_INITIAL_HEALTH = 250;
        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, ADVANCED_PLAYER_INITIAL_HEALTH)
        {
        }
    }
}
