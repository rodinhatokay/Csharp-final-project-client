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
using System.Windows.Media.TextFormatting;
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
        private bool gameEnded = false;
        private string otherPalyerUS;
        public Game(FIARServiceClient client, string us, ClientCallback callback, bool turn, WaitingRoom waitingRoom, string otherPalyerUS)
        {
            InitializeComponent();
            this.waitingRoom = waitingRoom;
            this.callback = callback;
            this.Client = client;
            this.callback.madeMove = UpdateGame;
            this.turn = turn;

            SetTurn();
            callback.EndGame = this.EndGame;
            playerColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            opponentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Yellow"));
            SetUsers(us, otherPalyerUS);
            SetGui();
        }

        private void SetUsers(string og, string otherPlayer)
        {
            otherPalyerUS = otherPlayer;
            UserName = og;
            lbUsername.Content = og;
            lbOtherPlayerUS.Content = otherPlayer;
        }

        private void SetTurn()
        {
            string text = turn ? "Your turn" : "Not your turn";
            this.labelTurn.Content = text;
        }


        private bool animating = false;

        private SolidColorBrush playerColor;
        private SolidColorBrush opponentColor;
        private SolidColorBrush whiteColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
        private WaitingRoom waitingRoom;

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
            MoveResult state = MoveResult.NotYourTurn;
            try
            {

                if (turn && !animating)
                {
                    var el = sender as Ellipse;
                    int col = myUG.Children.IndexOf(el) % 7;
                    var result = Client.ReportMove(this.UserName, col);
                    state = result;
                    if (result == MoveResult.NotYourTurn || result == MoveResult.IlligelMove)
                    {
                        //MessageBox.Show("Not your turn");
                        return;
                    }

                    await Animate_Click(result, el);
                }
                turn = !turn;
                if (state == MoveResult.GameOn)
                    SetTurn();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }


        private void EndGame(MoveResult res)
        {
            if (res != MoveResult.GameOn && res != MoveResult.IlligelMove && res != MoveResult.NotYourTurn)
            {
                if (res == MoveResult.PlayerLeft)
                    MessageBox.Show("Your opponent left, You Won!");
                if (res == MoveResult.Draw)
                    MessageBox.Show("Game ended, it's a Draw");
                if (res == MoveResult.YouWon)
                    MessageBox.Show("Game ended, You Won");
                if (res == MoveResult.YouLost)
                    MessageBox.Show("Game ended, You Lost");
                animating = true;

                gameEnded = true;
                this.labelTurn.Content = "Game over";
            }


            //throw new NotImplementedException();
        }

        private async Task UpdateGame(MoveResult result, int location)
        {
            animating = true;
            turn = true;
            SetTurn();
            await animate(location, opponentColor);
            animating = false;
            EndGame(result);
        }

        private async Task Animate_Click(MoveResult result, Ellipse el)
        {
            animating = true;
            int index = myUG.Children.IndexOf(el) % 7;
            await animate(index, playerColor);
            animating = false;
            EndGame(result);

        }

        private async Task animate(int index, SolidColorBrush color)
        {

            for (int j = index; j < 42; j += 7)
            {
                Ellipse ellToAnimate = myUG.Children[j] as Ellipse;
                if (ellToAnimate.Fill != whiteColor)
                {

                    (myUG.Children[j - 7] as Ellipse).Fill = color;
                    break;

                }

                if (j >= 35)
                {
                    ellToAnimate.Fill = color;
                    break;
                }
                ellToAnimate.Fill = color;
                await Task.Delay(60);
                ellToAnimate.Fill = whiteColor;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!gameEnded)
                    Client.Disconnected(UserName);
                Client.SetAsAvailablePlayer(this.UserName);
                waitingRoom.UpdatePlayersAvailable();
                waitingRoom.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
