using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players.Entities
{
    public class CivilPlayer : Player, IPlayer
    {
        private const int INITIAL_LIFE_POINTS = 50;
        public CivilPlayer(string name) 
            : base(name, INITIAL_LIFE_POINTS)
        {
        }
    }
}
