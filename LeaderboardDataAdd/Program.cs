using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mao;
namespace LeaderboardDataAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            LeaderboardData db = new LeaderboardData();
            using (db)
            {
                //Base population of leaderboard
                Leaderboard l1 = new Leaderboard() { PlayerID = 1, Username = "ABC", Streak = 5, Date = new DateTime(2022, 4, 3, 1, 24, 0) };
                Leaderboard l2 = new Leaderboard() { PlayerID = 2, Username = "DLR", Streak = 3, Date = new DateTime(2022, 3, 17, 1, 14, 0) };
                Leaderboard l3 = new Leaderboard() { PlayerID = 3, Username = "CRD", Streak = 2, Date = new DateTime(2022, 7, 4, 3, 9, 0) };
                db.Players.Add(l1);
                db.Players.Add(l2);
                db.Players.Add(l3);
                Console.WriteLine("Leaderboard added to db");
                db.SaveChanges();
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
