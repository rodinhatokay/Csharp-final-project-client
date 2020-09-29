using FIARClient.ServiceReference1;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
    /// this is the "main page" for players it display all players available and on click display stats of the player
    /// button to varity of searchs for stats of games/players
    /// anoter button for sending request to player selected
    /// </summary>
    public partial class WaitingRoom : Window
    {
        public string UserName { get; internal set; }
        public FIARServiceClient Client { get; internal set; }

        List<PlayerInfo> players;
        private ClientCallback callback;

        /// <summary>
        /// gets host service and username and callback for the player 
        /// </summary>
        /// <param name="clinet"></param>
        /// <param name="us"></param>
        /// <param name="callback"></param>
        public WaitingRoom(FIARServiceClient clinet, string us, ClientCallback callback)
        {
            InitializeComponent();
            this.callback = callback;
            callback.invatation += InviteRecieved;
            callback.getPlayers += GetPlayers;
            Client = clinet;
            UserName = us;
            players = new List<PlayerInfo>();

        }

        private bool error = false;


        /// <summary>
        /// sends request to host as make this player available and requests for list player 
        /// </summary>
        public void UpdatePlayersAvailable()
        {
            try
            {
                Client.SetAsAvailablePlayer(this.UserName);
                players = Client.GetAvalibalePlayers();
                lbWaitingRoom.ItemsSource = initPlayers(players);
            }
            catch (TimeoutException ex)
            {
                serverLost();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// given players sets as available players to play with and displays on list view
        /// </summary>
        /// <param name="players"></param>
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


        /// <summary>
        /// callback from host to receive invite from username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool InviteRecieved(string username)
        {
            InvitationDialog dialog = new InvitationDialog();
            dialog.Label.Content = "Invitation to a game from " + username;
            dialog.ShowDialog();
            if (dialog.Result == true)
            {
                Game g = new Game(Client, this.UserName, this.callback, false, username);

                g.Show();
                this.Hide();
                return true;

            }
            return false;
        }

        /// <summary>
        /// button handles request player to play 
        /// and sends invite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_req_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbWaitingRoom.SelectedIndex == -1)
                {
                    MessageBox.Show("You need to pick an opponent");
                    return;
                }
                PlayerInfo pi = lbWaitingRoom.SelectedItem as PlayerInfo;
                string name = pi.username;
                bool result = Client.InvitationSend(UserName, name);
                if (result == true)
                {
                    Game g = new Game(Client, this.UserName, this.callback, true, name);

                    g.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(name + "DECLINED YOUR INVITE");
                }
            }
            catch (FaultException<OpponentNotAvailableFault> ex)
            {
                MessageBox.Show(ex.Detail.Details);
            }
            catch (FaultException<OpponentDisconnectedFault> ex)
            {
                MessageBox.Show(ex.Detail.Details);
            }
            catch (TimeoutException ex)
            {
                serverLost();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            Search searchWindow = new Search(Client);
            searchWindow.Client = Client;
            searchWindow.Show();

        }


        /// <summary>
        /// called when window is closed
        /// sends to host as player logged out 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!error)
            {
                try
                {

                    Client.PlayerLogout(UserName);
                }
                catch (Exception)
                {
                    Environment.Exit(Environment.ExitCode);
                }
            }
        }

        /// <summary>
        /// called when lost connection with server
        /// </summary>
        public void serverLost()
        {

            error = true;
            this.Close();
            MessageBox.Show("Sorry,Connection with the server was lost");
            MainWindow m = new MainWindow();
            m.Show();

        }

        private void lbWaitingRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbWaitingRoom.SelectedIndex == -1)
            {
                return;
            }
            PlayerInfo pi = lbWaitingRoom.SelectedItem as PlayerInfo;

            tbWins.Text = pi.Wins.ToString();
            tbLoses.Text = pi.Loses.ToString();
            tbScore.Text = pi.Score.ToString();
            tbPercent.Text = (pi.Games == 0) ? "0" : (pi.Wins * 100 / pi.Games).ToString();
            lbInfo.ItemsSource = pi.PlayedAgainst;
        }
        private void MI_2players_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchBy2Players windowSearch = new SearchBy2Players(Client, this);
                windowSearch.Client = Client;
                windowSearch.Show();
            }
            catch (TimeoutException ex)
            {
                serverLost();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MI_gamesEnded_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllGames searchWindow = new AllGames(Client);
                searchWindow.Client = Client;
                searchWindow.Show();
            }
            catch (TimeoutException ex)
            {
                serverLost();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MI_gamesOngoing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OngoingGames searchWindow = new OngoingGames(Client, this);
                searchWindow.Client = Client;
                searchWindow.Show();
            }
            catch (TimeoutException ex)
            {
                serverLost();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            UpdatePlayersAvailable();
        }
    }
}
