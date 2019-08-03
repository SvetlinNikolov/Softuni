using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

using System;


namespace PlayersAndMonsters.Models.Players.Entities
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        //Maybe doesnt need setter
        public ICardRepository CardRepository { get; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Exceptions.UsernameNullOrEmpty);
                }
                this.username = value;
            }

        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (this.health < 0)
                {
                    throw new ArgumentException(Exceptions.PlayerBonusLessThanZero);
                }
                this.health = value;
            }
        }

        public bool IsDead
        {
            get
            {
                if (this.health == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException(Exceptions.DamagagePointsLessThanZero);
            }


            //NOT SURE ABOUT THIS RICK
            int currentHealth = this.health;

            if (currentHealth - damagePoints <= 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }

        }
    }
}
