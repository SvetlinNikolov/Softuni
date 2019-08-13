using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players.Entities
{
    public class MainPlayer : Player, IPlayer
    {
        private const int INITIAL_LIFE_POINTS = 100;
        private const string CONSTANT_NAME = "Tommy Vercetti";
        public MainPlayer() 
            : base(CONSTANT_NAME, INITIAL_LIFE_POINTS)
        {
        }
    }
}
