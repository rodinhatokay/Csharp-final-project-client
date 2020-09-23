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
    /// Interaction logic for OngoingGames.xaml
    /// </summary>
    public partial class OngoingGames : Window
    {
        public FIARServiceClient Client { get; internal set; }
        public OngoingGames(FIARServiceClient Client)
        {
            this.Client = Client;
            InitializeComponent();
            dgData.ItemsSource = Client.GetOngoingGames();
        }
    }
}
