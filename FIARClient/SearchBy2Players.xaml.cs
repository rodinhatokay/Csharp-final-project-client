﻿using FIARClient.ServiceReference1;
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
using System.Windows.Controls.DataVisualization;


namespace FIARClient
{
    /// <summary>
    /// Interaction logic for SearchBy2Players.xaml
    /// </summary>
    public partial class SearchBy2Players : Window
    {
        public FIARServiceClient Client { get; internal set; }
        public IEnumerable Result { get; internal set; }

        private List<player> Players { get; set; }

        public SearchBy2Players(FIARServiceClient Client)
        {
            this.Client = Client;
            InitializeComponent();
            resetLabels();

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            try
            {
                Players = player.initList(Client.GetAllPlayers());
                cbFirstActors.ItemsSource = new List<player>(Players);
                cbSecondActors.ItemsSource = new List<player>(Players);
            }
            catch (Exception)
            {

            }
        }


        private void cbSecondActors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var l = Players.Where(x => x.username != cbSecondActors.SelectedItem.ToString());
            cbFirstActors.ItemsSource = l;
            if (cbFirstActors.SelectedIndex != -1 && cbSecondActors.SelectedIndex != -1)
                getData((player)cbFirstActors.SelectedItem, (player)cbSecondActors.SelectedItem);
            else resetLabels();
        }

        private void cbFirstActors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var l = Players.Where(x => x.username != cbFirstActors.SelectedItem.ToString());
            cbSecondActors.ItemsSource = l;
            if (cbFirstActors.SelectedIndex != -1 && cbSecondActors.SelectedIndex != -1)
                getData((player)cbFirstActors.SelectedItem, (player)cbSecondActors.SelectedItem);
            else resetLabels();
        }

        private void resetLabels()
        {
            label_player1_wins.Content = "?";
            label_player2_wins.Content = "?";
            label_tie.Content = "?";
            label_player1_games_wins.Content = "?";
            label_player2_games_wins.Content = "?";
            label_games_tie.Content = "?";
            label_player1_points.Content = "?";
            label_player2_points.Content = "?";
        }
        private void getData(player p1, player p2)
        {
            var res = Client.GetPlayersGames(p1.username, p2.username);

            int player1Wins = 0;
            int player2Wins = 0;

            int player1Score = 0;
            int player2Score = 0;

            foreach (var g in res)
            {
                if (g.Winner_id == p1.id)
                    player1Wins++;
                if (g.Winner_id == p2.id)
                {
                    player2Wins++;
                }
                if (p1.id == g.Player1_id)
                {
                    player1Score += g.Player1Points;
                    player2Score += g.Player2Points;
                }
                else
                {
                    player2Score += g.Player1Points;
                    player1Score += g.Player2Points;
                }
            }
            label_player1_wins.Content = (player1Wins * 100 / res.Count).ToString() + "%";
            label_player2_wins.Content = (player2Wins * 100 / res.Count).ToString() + "%";
            label_tie.Content = ((res.Count - player1Wins - player2Wins) * 100 / res.Count).ToString() + "%";

            label_player1_games_wins.Content = player1Wins;
            label_player2_games_wins.Content = player2Wins;
            label_games_tie.Content = (res.Count - player1Wins - player2Wins);

            label_player1_points.Content = player1Score;
            label_player2_points.Content = player2Score;

        }
    }


}
