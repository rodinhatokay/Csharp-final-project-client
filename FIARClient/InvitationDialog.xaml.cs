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
    /// Interaction logic for InvitationDialog.xaml
    /// dialog invation 
    /// </summary>
    public partial class InvitationDialog : Window
    {

        public bool Result { get; set; }
        public InvitationDialog()
        {
            InitializeComponent();
        }

        private void btnDecline_Click(object sender, RoutedEventArgs e)
        {
            Result = false;
            Close();
        }

        private void btnAcc_Click(object sender, RoutedEventArgs e)
        {
            Result = true;
            Close();
        }
    }
}
