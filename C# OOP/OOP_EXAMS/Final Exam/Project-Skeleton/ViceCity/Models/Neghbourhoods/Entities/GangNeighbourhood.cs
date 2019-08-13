using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Guns.Entities;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods.Entities
{
    public class GangNeighbourhood : INeighbourhood
    {

        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            List<IGun> playerGunsList = mainPlayer.GunRepository.Models.ToList();
            List<IPlayer> civilPlayersList = civilPlayers.ToList();



            foreach (var item in playerGunsList.ToList())
            {
                while (item.CanFire)
                {
                    foreach (var civilPlayer in civilPlayersList)
                    {
                        if (civilPlayer.LifePoints > 0)
                        {
                            civilPlayer.LifePoints-=item.Fire();
                            //civilPlayers.FirstOrDefault(x => x.Name == civilPlayer.Name).TakeLifePoints(item.Fire());
                        }
                        else
                        {
                            civilPlayersList.Remove(civilPlayer);
                           
                        }

                    }
                }
            }

            //end of mainPlayerAttack

            foreach (var civilPlayer in civilPlayers)
            {
                foreach (var gun in civilPlayer.GunRepository.Models)
                {
                    while (gun.CanFire)
                    {
                        if (mainPlayer.IsAlive)
                        {
                            mainPlayer.TakeLifePoints(gun.Fire());
                        }
                       

                    }
                }
            }
           

        }
    }
}
