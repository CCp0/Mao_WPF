using System;
using System.Windows;
using Newtonsoft.Json;
using System.IO;

namespace Mao
{
    /// <summary>
    /// Interaction logic for InputPlayerDetails.xaml
    /// </summary>
    public partial class InputPlayerDetails : Window
    {
        string errFilePath = "../ErrorLog.txt", lbJSONfilePath = "../LeaderboardJSON.txt";
        public InputPlayerDetails()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LeaderboardData db = new LeaderboardData();
                using (db)
                {
                    //Base population of leaderboard
                    Leaderboard newEntry = new Leaderboard() { PlayerID = 1, Username = tbxNameInput.Text, Streak = (int)((MainWindow)Application.Current.MainWindow).lblStreak.Content, Date = DateTime.Now };
                    db.Players.Add(newEntry);
                    db.SaveChanges();
                    //Sending the table to JSON text file
                    string JSONstring = JsonConvert.SerializeObject(db.Players);
                    File.WriteAllText(lbJSONfilePath, JSONstring);
                    //Reset game
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message + " Depending on the pc it seems to cause this error for the forced restart");
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
    }
}
