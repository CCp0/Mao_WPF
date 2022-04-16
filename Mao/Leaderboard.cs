using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mao
{
    public class Leaderboard
    {
        public int PlayerID { get; set; }
        public string Username { get; set; }
        public int Streak { get; set; }
        public DateTime Date {get;set;}
    }
    public class LeaderboardData : DbContext
    {
        public LeaderboardData() : base("LeaderboardData") { }

        public DbSet<Leaderboard> Players { get; set; }
    }
}