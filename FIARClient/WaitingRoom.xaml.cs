using FIARClient.ServiceReference1;
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

namespace FIARClient
{
    /// <summary>
    /// Interaction logic for WaitingRoom.xaml
    /// </summary>
    public partial class WaitingRoom : Window
    {
        public string UserName { get; internal set; }
        public FIARServiceClient Client { get; internal set; }

        List<PlayerInfo> players;
        private ClientCallback callback;
        public WaitingRoom(FIARServiceClient clinet, string us, ClientCallback callback)
        {
            InitializeComponent();
            this.callback = callback;
            callback.invatation += InviteRecieved;
            callback.getPlayers += GetPlayers;
            Client = clinet;
            UserName = us;
            players = new List<PlayerInfo>();
            try
            {
                players = Client.GetAvalibalePlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            lbWaitingRoom.ItemsSource = initPlayers(players);
        }


        private void GetPlayers(List<PlayerInfo> players)
        {
            this.players = players;



            lbWaitingRoom.ItemsSource = initPlayers(players);
        }

        private List<player> initPlayers(List<PlayerInfo> players)
        {
            List<player> pl = new List<player>();
            players.ForEach(i =>
            {
                if (UserName != i.username)
                    pl.Add(new player(i));
            });
            return pl;
        }

        public bool InviteRecieved(string username)
        {
            InvitationDialog dialog = new InvitationDialog();
            dialog.Label.Content = "Invitation to a game from " + username;
            dialog.ShowDialog();

            if (dialog.Result == true)
            {
                Game g = new Game(Client, this.UserName, this.callback, false);
                //this.Hide();
                g.Show();
                //this.Show();
                return true;
            }
            return false;
        }



        private void btn_req_Click(object sender, RoutedEventArgs e)
        {
            PlayerInfo pi = lbWaitingRoom.SelectedItem as PlayerInfo;
            string name = pi.username;
            bool result = Client.InvatationSend(UserName, name);
            if (result == true)
            {
                Game g = new Game(Client, this.UserName, this.callback, true);
                //this.Hide();
                g.Show();
                //this.Show();

                //MessageBox.Show(name + "ACCEPTED TO PLAY WITH YOU");

            }
            else
            {
                MessageBox.Show(name + "DECLINED YOUR INVITE");
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            Search searchWindow = new Search(Client);
            searchWindow.Client = Client;
            searchWindow.Show();

        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Client.PlayerLogout(UserName);
            Environment.Exit(Environment.ExitCode);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

        }



        private void lbWaitingRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayerInfo pi = lbWaitingRoom.SelectedItem as PlayerInfo;

            tbWins.Text = pi.Wins.ToString();
            tbLoses.Text = pi.Loses.ToString();
            tbScore.Text = pi.Score.ToString();
            //tbPercent.Text = (pi.PlayedAgainst.Count == 0)? "0" : (pi.Wins * 100 / pi.PlayedAgainst.Count).ToString();
        }
    }
}
