using FIARClient.ServiceReference1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
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
    /// Interaction logic for SearchBy2Players.xaml
    /// </summary>
    public partial class SearchBy2Players : Window
    {
        public FIARServiceClient Client { get; internal set; }
        public IEnumerable Result { get; internal set; }

        private List<string> Players { get; set; }

        public SearchBy2Players()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            try
            {
                //Players = Client.GetAllPlayer();
                cbFirstActors.ItemsSource = new List<string>(Players);
                cbSecondActors.ItemsSource = new List<string>(Players);
            }
            catch (Exception)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbSecondActors.SelectedIndex == -1 || cbFirstActors.SelectedIndex == -1)
            {
                MessageBox.Show("You must select in both lists");
                return;
            }
            try
            {
                //Result = Client.GetGames(cbFirstActors.SelectedItem, cbSecondActors.SelectedItem);
                Close();
            }
            catch (Exception)
            {

            }
        }

        private void cbSecondActors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbFirstActors.ItemsSource = new List<string>(Players);
            cbFirstActors.Items.Remove(cbSecondActors.SelectedItem);
        }

        private void cbFirstActors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbSecondActors.ItemsSource = new List<string>(Players);
            cbSecondActors.Items.Remove(cbFirstActors.SelectedItem);
        }
    }
}
