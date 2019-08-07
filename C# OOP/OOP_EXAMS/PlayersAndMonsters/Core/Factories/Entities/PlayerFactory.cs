using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.Entities;
using PlayersAndMonsters.Repositories.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories.Entities
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {

            CardRepository cardRepository = new CardRepository();

            IPlayer player = null;

            if (type.ToLower() == "beginner")
            {
                Beginner beginner = new Beginner(cardRepository, username);
                player = beginner;
            }
            else if (type.ToLower() == "advanced".ToLower())
            {
                Advanced advanced = new Advanced(cardRepository, username);
                player = advanced;
            }

            return player;
        }
    }
}
