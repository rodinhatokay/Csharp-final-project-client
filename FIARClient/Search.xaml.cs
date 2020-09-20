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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public FIARServiceClient Client { get; internal set; }

        public Search(FIARServiceClient Client)
        {
            this.Client = Client;
            InitializeComponent();
            dgData.ItemsSource = Client.GetAllPlayers();
            int a = dgData.Columns.Count;

        }

        private void MI_UserName_Click(object sender, RoutedEventArgs e)
        {
            SearchBy searchBy = new SearchBy();
            searchBy.Client = Client;
            searchBy.Label.Content = "Search by  user Name:";
            searchBy.Status = SearchByStatus.UserName;
            searchBy.ShowDialog();
            dgData.ItemsSource = searchBy.Result;
        }

        private void MI_gamesPlayed_Click(object sender, RoutedEventArgs e)
        {
            SearchBy searchBy = new SearchBy();
            searchBy.Client = Client;
            searchBy.Label.Content = "Search by games Count:";
            searchBy.Status = SearchByStatus.Games;
            searchBy.ShowDialog();
            dgData.ItemsSource = searchBy.Result;

        }

        private void MI_wins_Click(object sender, RoutedEventArgs e)
        {
            SearchBy searchBy = new SearchBy();
            searchBy.Client = Client;
            searchBy.Label.Content = "Search by wins Count:";
            searchBy.Status = SearchByStatus.Wins;
            searchBy.ShowDialog();
            dgData.ItemsSource = searchBy.Result;

        }

        private void MI_loses_Click(object sender, RoutedEventArgs e)
        {
            SearchBy searchBy = new SearchBy();
            searchBy.Client = Client;
            searchBy.Label.Content = "Search by loses Count:";
            searchBy.Status = SearchByStatus.Loses;
            searchBy.ShowDialog();
            dgData.ItemsSource = searchBy.Result;

        }

        private void MI_score_Click(object sender, RoutedEventArgs e)
        {
            SearchBy searchBy = new SearchBy();
            searchBy.Client = Client;
            searchBy.Label.Content = "Search by score:";
            searchBy.Status = SearchByStatus.Score;
            searchBy.ShowDialog();
            dgData.ItemsSource = searchBy.Result;

        }

        private void MI_allgames_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //lbItems.ItemsSource = Client.GetAllGame();
            }
            catch (Exception)
            {

            }
        }

        private void MI_currentlyplaying_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //lbItems.ItemsSource = Client.GetCurrentPlayers();

            }
            catch (Exception)
            {

            }
        }

        private void MI_2players_Click(object sender, RoutedEventArgs e)
        {
            SearchBy2Players windowSearch = new SearchBy2Players(Client);
            windowSearch.Client = Client;
            windowSearch.ShowDialog();
            dgData.ItemsSource = windowSearch.Result;
        }

    }

}
