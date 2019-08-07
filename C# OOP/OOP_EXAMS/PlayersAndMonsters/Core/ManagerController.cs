namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Core.Factories.Entities;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Entities;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Repositories.Enitities;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IPlayerFactory playerFactory;
        private readonly ICardRepository cardRepository;
        private readonly ICardFactory cardFactory;
        private readonly IBattleField battleField;
        public ManagerController()
        {
            cardRepository = new CardRepository();
            cardFactory = new CardFactory();
            playerFactory = new PlayerFactory();
            battleField = new BattleField();
            playerRepository = new PlayerRepository();
        }

        public string AddPlayer(string type, string username)
        {
            var playerToAdd = playerFactory.CreatePlayer(type, username);

            playerRepository.Add(playerToAdd);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var cardToAdd = cardFactory.CreateCard(type, name);

            cardRepository.Add(cardToAdd);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var cardToAddToPlayer = cardRepository.Find(cardName);
            var player = playerRepository.Find(username);

            player.CardRepository.Add(cardToAddToPlayer);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepository.Find(attackUser);
            var enemy = playerRepository.Find(enemyUser);

            battleField.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Cards.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints }");
                }
                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
