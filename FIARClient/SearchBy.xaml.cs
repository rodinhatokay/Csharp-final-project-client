using FIARClient.ServiceReference1;
using System;
using System.Collections;
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
    /// Interaction logic for SearchBy.xaml
    /// </summary>
    /// 
    enum SearchByStatus { UserName, Games, Wins, Loses, Score }
    public partial class SearchBy : Window
    {
        public SearchBy()
        {
            InitializeComponent();
        }
        public FIARServiceClient Client { get; internal set; }
        public IEnumerable Result { get; internal set; }
        internal SearchByStatus Status { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbInput.Text))
            {
                MessageBox.Show("empty input please insert input");
                return;
            }
            try
            {
                switch (Status)
                {
                    case SearchByStatus.UserName:
                        // Result = Client.SearchUserName(Label.Content.ToString().Trim());
                        Close();
                        break;
                    case SearchByStatus.Games:
                        //Result = Client.SearchByGamesCount(Int32.Parse(Label.Content.ToString().Trim()));
                        Close();
                        break;
                    case SearchByStatus.Wins:
                        //Result = Client.SearchByWinsCount((Int32.Parse(Label.Content.ToString().Trim()));
                        Close();
                        break;
                    case SearchByStatus.Loses:
                        //Result = Client.SearchByLosescount(Int32.Parse(Label.Content.ToString().Trim()));
                        Close();
                        break;
                    case SearchByStatus.Score:
                        //Result = Client.SearchByScore(Int32.Parse(Label.Content.ToString().Trim()));
                        Close();
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Input string was not in a correct format.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
