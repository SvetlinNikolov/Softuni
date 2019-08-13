using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Guns.Entities;
using ViceCity.Models.Neghbourhoods.Entities;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Players.Entities;
using ViceCity.Repositories.Entities;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private MainPlayer mainPlayer;
        private GunRepository gunRepository;
        private GangNeighbourhood gangNeighbourhood;
        private List<IPlayer> players;
        private Queue<IGun> guns;
        public Controller()
        {
            this.mainPlayer = new MainPlayer();

            this.mainPlayer.GunRepository = new GunRepository();

            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
            this.players = new List<IPlayer>();
            this.guns = new Queue<IGun>();
        }
        public string AddGun(string type, string name)
        {
            IGun gunToAdd = null;

            if (type == "Pistol")
            {
                gunToAdd = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gunToAdd = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.guns.Enqueue(gunToAdd);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }
            if (name == "Vercetti")
            {
                IGun gunToAdd = this.guns.Dequeue();
                mainPlayer.GunRepository.Add(gunToAdd);
                return $"Successfully added {gunToAdd.Name} to the Main Player: Tommy Vercetti";
            }
            IPlayer playerToAddGunTo = this.players.FirstOrDefault(x => x.Name == name);

            if (playerToAddGunTo == null)
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                IGun gunToAdd = this.guns.Dequeue();
                playerToAddGunTo.GunRepository.Add(gunToAdd);
                return $"Successfully added {gunToAdd.Name} to the Civil Player: {playerToAddGunTo.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            CivilPlayer civilPlayer = new CivilPlayer(name);
            civilPlayer.GunRepository = new GunRepository();
            this.players.Add(civilPlayer);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int mainPlayerInitialHp = this.mainPlayer.LifePoints;
            int initialPlayersHp = this.players.Sum(x => x.LifePoints);
            this.gangNeighbourhood.Action(this.mainPlayer, this.players);

          

            if (this.mainPlayer.LifePoints == mainPlayerInitialHp
                && this.players.Sum(x => x.LifePoints) == initialPlayersHp)
            {
                return "Everything is okay!";
            }
            else
            {
                //                "A fight happened:"
                //"Tommy live points: {mainPlayerLifePoints}!"
                //"Tommy has killed: {deadCivilPlayers} players!"
                //"Left Civil Players: {civilPlayersCount}!"

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("A fight happened:")
                    .AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!")
                    .AppendLine($"Tommy has killed: {this.players.Where(x => x.LifePoints == 0).Count()} players!")
                    .AppendLine($"Left Civil Players: {this.players.Where(x => x.LifePoints > 0).Count()}!");

                return sb.ToString().TrimEnd();

            }
        }
    }
}
