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
using System.Windows.Shapes;

namespace FIARClient
{
    /// <summary>
    /// Interaction logic for RegisterAcc.xaml
    /// regiseteration window 
    /// </summary>
    public partial class RegisterAcc : Window
    {
        public RegisterAcc()
        {
            InitializeComponent();
        }



        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (AllBoxesFilled())
            {
                if (tbPass.Password.ToString().Equals(tbPass2.Password.ToString()))
                {
                    ClientCallback callback = new ClientCallback();
                    FIARServiceClient client = new FIARServiceClient(new InstanceContext(callback));
                    string un = tbUserName.Text.Trim();
                    string pass = tbPass.Password.ToString();
                    try
                    {
                        client.RegisterPlayer(un,pass);
                        MessageBox.Show("Successfully added");
                    }
                    catch (FaultException<PlayerAlreadyExistsInDataBase> ex)
                    {
                        MessageBox.Show(ex.Detail.Details);
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
                else
                {
                    MessageBox.Show("passwords are not matching please insert matching passwords");
                }
            }
            else
            {
                MessageBox.Show("You must fill all details");
            }
        }

        private bool AllBoxesFilled()
        {
            if (string.IsNullOrEmpty(tbUserName.Text))
                return false;
            if (string.IsNullOrEmpty(tbPass.Password.ToString()))
                return false;
            if (string.IsNullOrEmpty(tbPass2.Password.ToString()))
                return false;
            return true;
        }
    }
}
