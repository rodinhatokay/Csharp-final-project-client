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

namespace FIARClient
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
            playerColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            opennetColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Yellow"));

            SetGui();
        }
        private bool animating = false;

        private SolidColorBrush playerColor;
        private SolidColorBrush opennetColor;
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
            Ellipse el = sender as Ellipse;
            if(!animating)
            {
                animating = true;
                await Animate_Click(el);
            }
        }

        private async Task Animate_Click(Ellipse el)
        {
            while(animating)
            {
                int i = myUG.Children.IndexOf(el);
                int cul = i % 7;
                for (int j = cul; j < 42; j = j + 7)
                {
                    myUG.InvalidateVisual();
                    Ellipse ellToAnimate = myUG.Children[j] as Ellipse;

                    if (ellToAnimate.Fill == playerColor || ellToAnimate.Fill == opennetColor)
                    {
                        if (j - 7 > -1)
                        {
                            Ellipse ellToFill = myUG.Children[j - 7] as Ellipse;
                            ellToFill.Fill = playerColor;
                        }
                        animating = false;
                        break;
                    }
                    else if (j + 7 > 41)
                    {
                        ellToAnimate.Fill = playerColor;
                        animating = false;
                    }
                    else
                    {
                        ellToAnimate.Fill = playerColor;
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
