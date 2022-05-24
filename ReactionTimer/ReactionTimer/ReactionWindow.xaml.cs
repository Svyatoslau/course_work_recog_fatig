using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ReactionTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReactionWindow : Page
    {
        private static double score;
        private Random rng = new Random();
        private DispatcherTimer timer = new DispatcherTimer();
        private Stopwatch timerRed = new Stopwatch();

        public ReactionWindow()
        {
            this.InitializeComponent();   
            timer.Interval = new TimeSpan(0, 0, 0, rng.Next(1,5), 0);
            timer.Tick += timer_Tick;
            timer.Start();
                
        }

       
        private void timer_Tick(object sender, object e)
        {
            ReactionBackground.Background = new SolidColorBrush(Windows.UI.Colors.Red);
            myText.Text = "TAP NOW!!!";
            timerRed.Start();
            timer.Stop();           
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        private void background_Tapped(object sender, TappedRoutedEventArgs e)
        {
            score = timerRed.ElapsedMilliseconds;
            timerRed.Stop();
            this.Frame.Navigate(typeof(ResultWindow));                       
        }

        public static double getScore()
        {
            return score;
        }

    }
}
