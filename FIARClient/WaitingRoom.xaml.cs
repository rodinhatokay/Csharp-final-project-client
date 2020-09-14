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
        public WaitingRoom()
        {
            InitializeComponent();
        }

        List<PlayerInfo> players;
        private ClientCallback callback;

        public WaitingRoom(FIARServiceClient clinet, string us)
        {

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
            InitializeComponent();
        }

        public WaitingRoom(FIARServiceClient clinet, string us, ClientCallback callback) : this(clinet, us)
        {
            this.callback = callback;
            callback.invatation += InviteRecieved;
        }

        public bool InviteRecieved(string username)
        {
            InvitationDialog dialog = new InvitationDialog();
            dialog.Label.Content = "Invitation to a game from " + username;
            dialog.ShowDialog();
            return false;
            //if (dialog.Result == true)
            //{
                
            //}
        }

        public string UserName { get; internal set; }
        public FIARServiceClient Client { get; internal set; }

        private void btn_req_Click(object sender, RoutedEventArgs e)
        {
            //get client name clicked on
            //send request and check what it returns
            //according to result display in messagebox
            var player = lbWaitingRoom.SelectedItem;

            
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            Search searchWindow = new Search();
            searchWindow.Client = Client;
            searchWindow.Show();

        }

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            lbWaitingRoom.ItemsSource = players;
        }



        private void lbWaitingRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayerInfo pi = lbWaitingRoom.SelectedItem as PlayerInfo;

            tbWins.Text = pi.Wins.ToString();
            tbLoses.Text = pi.Loses.ToString();
            tbScore.Text = pi.Score.ToString();
            tbPercent.Text = (pi.PlayedAgainst.Count == 0)? "0" : (pi.Wins * 100 / pi.PlayedAgainst.Count).ToString();
        }
    }
}
