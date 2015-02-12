using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Karaoke
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            // Register your event watchers here to avoid calling the functions
            // mutliple times for the same event trigger
            MediaPlayer.MediaFailed += MediaPlayer_MediaFailed;
            MediaPlayer.MediaOpened += new RoutedEventHandler(MediaPlayer_MediaOpened);
            timer.Tick += timer_Tick;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "*.mp3";
            ofd.Filter = "Media|*.mp4;*.avi;*.flv;*.mp3";
            ofd.ShowDialog();
            MediaPlayer.Source = new Uri(ofd.FileName);
        }

        void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            SongText.Text = MediaPlayer.Source.ToString();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            lblTimer.Content = String.Format("{0} / {1}", MediaPlayer.Position.ToString(@"mm\:ss"), MediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (MediaPlayer.Source != null && MediaPlayer.NaturalDuration.HasTimeSpan)
                lblTimer.Content = String.Format("{0} / {1}", MediaPlayer.Position.ToString(@"mm\:ss"), MediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        }

        private void MediaPlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }
    }
}