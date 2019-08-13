using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories.Enitities
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players = new List<IPlayer>();

        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players
        {
            get
            {
                return this.players.AsReadOnly();
            }

        }

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(Exceptions.PlayerIsNull);
            }

            var playerToLookFor = Players.FirstOrDefault(x => x.Username == player.Username);

            if (playerToLookFor != null)
            {

                throw new ArgumentException(string.Format(Exceptions.PlayerAlreadyExists, player.Username));
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            var playerToFind = this.Players.FirstOrDefault(x => x.Username == username);

            return playerToFind;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(Exceptions.PlayerIsNull);
            }

            return this.players.Remove(player);
        }
    }
}
