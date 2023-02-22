using System;
using System.Windows.Media;

namespace OSU_Player.ViewModel
{
    public class Sound {
        private MediaPlayer mediaPlayer;
        public bool IsPlay = false;
        private bool IsOpen = false;
        public bool IsSelect = false;
        private TimeSpan _Duration;
        public string path = "";
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
        public TimeSpan Time {
            get { return mediaPlayer.Position;}
            set { mediaPlayer.Position = value;}
        }
        public void Open() 
        {
            mediaPlayer.Close();
            mediaPlayer.Open(new System.Uri(path));
            IsSelect = false;
            IsPlay = false;
        }
        public void Play()
        {
            IsPlay = true;
            Volume = Volume;
            mediaPlayer.Play();
        }
        public void Pause()
        {
            IsPlay = false;
            mediaPlayer.Pause();
        }
    }
}