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
    /// Interaction logic for InputPlayerDetails.xaml
    /// </summary>
    public partial class InputPlayerDetails : Window
    {
        public InputPlayerDetails()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardData db = new LeaderboardData();
            using (db)
            {
                //Base population of leaderboard
                Leaderboard newEntry = new Leaderboard() { PlayerID = 1, Username = tbxNameInput.Text, Streak = (int)((MainWindow)Application.Current.MainWindow).lblStreak.Content, Date = DateTime.Now };
                db.Players.Add(newEntry);
                db.SaveChanges();
                //Reset game
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }
    }
}
