using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ReactionTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultWindow : Page
    {
        public ResultWindow()
        {
            this.InitializeComponent();
            if (ReactionWindow.getScore() == 0) Result.Text = "TOO SOON";
            else
            {
                DateTime now = DateTime.Now;
                var score = ReactionWindow.getScore();
                Result.Text += score + " Miliseconds";
                ReactionWindowSaveScore(now, score);
            }          
        }
        private async void ReactionWindowSaveScore(DateTime now, double score)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            
                StorageFile sampleFile = await storageFolder
               .GetFileAsync("reaction_data.csv");
                       
            await FileIO.AppendTextAsync(sampleFile,
                $"{now.Day}-{now.Month}-{now.Year};{now.TimeOfDay};{score}\n");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReactionWindow));
        }
    }
}
