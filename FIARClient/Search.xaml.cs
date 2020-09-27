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
            try
            {
                this.Client = Client;
                InitializeComponent();
                dgData.ItemsSource = Client.GetAllPlayers();
                int a = dgData.Columns.Count;
            }
            catch(TimeoutException)
            {
                MessageBox.Show("request timeout");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
