using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mao
{
    /// <summary>
    /// Interaction logic for LeaderboardPopUp.xaml
    /// </summary>
    public partial class LeaderboardPopUp : Window
    {
        public LeaderboardPopUp()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LeaderboardData db = new LeaderboardData();

            var query = from p in db.Players
                        orderby p.Streak descending
                        select new { UserName = p.Username, Streak = p.Streak, Date = p.Date };
            var results = query.ToList();
            dgLeaderboard.ItemsSource = results;
        }
    }
}
