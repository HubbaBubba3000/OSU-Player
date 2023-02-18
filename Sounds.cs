using System;
using System.Windows.Media;

namespace OSU_Player.ViewModel
{
    public class Sound {
        private MediaPlayer mediaPlayer;
        public bool IsPlay = false;
        private bool IsOpen = false;
        private TimeSpan _Duration;
        string path = "";
        public Sound()
        {
            mediaPlayer = new MediaPlayer(); 
            mediaPlayer.MediaOpened += new EventHandler(OnOpen);  
        }
        public TimeSpan Duration {
            get {return _Duration;}
        }
        public void AddOnOpen(EventHandler e) {
            mediaPlayer.MediaOpened += e;
        }
        public void AddOnEnd(EventHandler e) {
            mediaPlayer.MediaEnded += e;
        }
         private void OnOpen(object? sender, EventArgs e) {
            _Duration = mediaPlayer.NaturalDuration.TimeSpan;
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
        public void play()
        {
            IsPlay = true;
            mediaPlayer.Close();
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