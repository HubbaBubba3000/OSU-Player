using System.Runtime.InteropServices;
using System.Timers;
using System;
using System.Windows.Media;
namespace OSU_Player.ViewModel
{
    public class Sound {
        private MediaPlayer mediaPlayer;
        public bool IsPlay = false;
        private bool IsOpen = false;
        private double _Duration;
        Timer t;
        string path;
        public Sound()
        {
            mediaPlayer = new MediaPlayer();   
        }
        public double Duration {
            get { 
                return _Duration;
            }
            set {
                _Duration = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            }
        }
        public bool IsMuted {
            get { return mediaPlayer.IsMuted;}
            set { mediaPlayer.IsMuted = value;}
        }
        public double Volume {
            get { return mediaPlayer.Volume;}
            set { mediaPlayer.Volume = value;}
        }
        public double Time {
            get { return mediaPlayer.Position.TotalSeconds;}
            set { mediaPlayer.Position = TimeSpan.FromSeconds(value);}
        }
        public void Open(string File) 
        {
            path = File;
            IsOpen = true;
        }
        public void getpos(object sender, EventArgs e) {
            Console.WriteLine(mediaPlayer.Position);
        }
        public void play()
        {
            IsPlay = true;
            mediaPlayer.Open(new System.Uri(path));
            mediaPlayer.Play();
        }
        public void pause()
        {
            IsPlay = false;
            mediaPlayer.Pause();
        }
    }
}