using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Entities
{
    public class Beginner : Player
    {
        public const int INITIAL_BEGINNER_HEALTH = 50;
        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, INITIAL_BEGINNER_HEALTH)
        {

        }
    }
}
