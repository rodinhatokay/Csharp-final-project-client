using FIARClient.ServiceReference1;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FIARClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterAcc rgAcc = new RegisterAcc();
            rgAcc.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (AllboxesFilled())
            {
                try
                {
                    ClientCallback callback = new ClientCallback();
                    FIARServiceClient client = new FIARServiceClient(new InstanceContext(callback));

                    string username = tbUserName.Text.Trim();
                    string pass = tbPass.Password.ToString();

                    client.PlayerLogin(username, pass);
                    WaitingRoom waitingRoom = new WaitingRoom(client, username, callback);
                    this.Close();
                    waitingRoom.Show();
                }
                catch (FaultException<PlayerAlreadyConnectedFault> ex)
                {
                    MessageBox.Show(ex.Detail.Details);
                }
                catch (FaultException<PlayerDoesntExistInDataBase> ex)
                {
                    MessageBox.Show(ex.Detail.Details);
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool AllboxesFilled()
        {
            if (string.IsNullOrEmpty(tbUserName.Text))
                return false;
            if (string.IsNullOrEmpty(tbPass.Password.ToString()))
                return false;
            return true;
        }
    }
}
