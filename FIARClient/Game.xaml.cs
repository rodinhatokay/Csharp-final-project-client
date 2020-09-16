using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using FIARClient.ServiceReference1;

namespace FIARClient
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public string UserName { get; internal set; }
        public FIARServiceClient Client { get; internal set; }
        private ClientCallback callback;

        private bool turn;
        public Game(FIARServiceClient client, string us, ClientCallback callback, bool turn)
        {
            this.UserName = us;
            this.callback = callback;
            this.Client = client;
            this.turn = turn;

            InitializeComponent();
            playerColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            opponentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Yellow"));

            SetGui();
        }
        private bool animating = false;

        private SolidColorBrush playerColor;
        private SolidColorBrush opponentColor;
        private SolidColorBrush whiteColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));

        private void SetGui()
        {
            for (int i = 0; i < 42; i++)
            {
                SolidColorBrush color = whiteColor;
                Ellipse el = new Ellipse
                {

                    Fill = color,
                    Height = 50,
                    Width = 50,

                };
                el.MouseUp += Ellipse_MouseUp;
                myUG.Children.Add(el);
            }
        }



        private async void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (turn)
            {
                Ellipse el = sender as Ellipse;
                if (!animating)
                {
                    int col = myUG.Children.IndexOf(el) % 7;
                    var result = Client.ReportMove(this.UserName, col);
                    if (result == MoveResult.NotYourTurn)
                    {
                        MessageBox.Show("Not your turn");
                        return;
                    }
                    animating = true;
                    await Animate_Click(el);

                    if (result == MoveResult.Draw)
                    {
                        EndGame("Its a Draw");
                    }
                    else if (result == MoveResult.YouWon)
                    {
                        EndGame("You won!");
                    }
                }

                turn = false;
            }
        }

        private void EndGame(string v)
        {

            throw new NotImplementedException();
        }

        private async Task UpdateGame(int location)
        {

            await animate(location, opponentColor);
            turn = true;
        }

        private async Task Animate_Click(Ellipse el)
        {

            int index = myUG.Children.IndexOf(el) % 7;
            await animate(index, playerColor);

        }

        private async Task animate(int index, SolidColorBrush color)
        {

            while (animating)
            {
                for (int j = index; j < 42; j = j + 7)
                {
                    myUG.InvalidateVisual();
                    Ellipse ellToAnimate = myUG.Children[j] as Ellipse;

                    if (ellToAnimate.Fill == color || ellToAnimate.Fill == opponentColor)
                    {
                        if (j - 7 > -1)
                        {
                            Ellipse ellToFill = myUG.Children[j - 7] as Ellipse;
                            ellToFill.Fill = color;
                        }
                        animating = false;
                        break;
                    }
                    else if (j + 7 > 41)
                    {
                        ellToAnimate.Fill = color;
                        animating = false;
                    }
                    else
                    {
                        ellToAnimate.Fill = color;
                        await Task.Delay(60);
                        ellToAnimate.Fill = whiteColor;
                    }
                }
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
