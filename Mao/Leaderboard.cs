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
        public string username { get; set; }
        public int streak { get; set; }
        public DateTime date {get;set;}
    }
    public class LeaderboardData:DbContext
    {
        public LeaderboardData() : base("LeaderboardData") { }


        public DbSet<Leaderboard> XYZ { get; set; }
    }
}

