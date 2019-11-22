
using System;
using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{

    public class Game
    {
        public enum Results
        {
            Loss = -1,
            Draw = 0,
            Win = 1
        }
        public int GameId { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        public decimal HomeTeamBetRate { get; set; }
        public decimal AwayTeamBetRate { get; set; }
        public decimal DrawBetRate { get; set; }
        public Results Result { get; set; }
        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
        public ICollection<Bet> Bets { get; set; }

    }
}
