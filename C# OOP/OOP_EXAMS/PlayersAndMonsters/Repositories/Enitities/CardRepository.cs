using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories.Enitities
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards = new List<ICard>();
        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards
        {
            get
            {
                return this.cards.AsReadOnly();
            }
        }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(Exceptions.CardIsNull);
            }

            if (this.Cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException(string.Format(Exceptions.CardAlreadyExists, card.Name));
            }
            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            var cardToReturn = this.Cards.FirstOrDefault(x => x.Name == name);

            return cardToReturn;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(Exceptions.CardIsNull);
            }
            return this.cards.Remove(card);
        }
    }
}
