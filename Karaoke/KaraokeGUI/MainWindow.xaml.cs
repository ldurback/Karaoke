﻿using Microsoft.Win32;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "*.*";
            ofd.Filter = "Media(*.*)|*.*";
            ofd.ShowDialog();
            MediaPlayer.MediaOpened += new RoutedEventHandler(MediaPlayer_MediaOpened);
            MediaPlayer.Source = new Uri(ofd.FileName);
        }


        void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            SongText.Text = MediaPlayer.Source.ToString();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();

            if (MediaPlayer.Source != null)
                lblTimer.Content = String.Format("{0} / {1}", MediaPlayer.Position.ToString(@"mm\:ss"), MediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblTimer.Content = "No file selected...";

        }
    }
}