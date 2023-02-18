using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;
using System.IO;
using OSU_Player.Json;
using System;

namespace OSU_Player.ViewModel
{
    public class BaseVM : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel : BaseVM
    {
       #region properties
        Config? c;
        string path = "";
        public Sound Player;
        private int _SelectedIndex;
        private BitmapImage _BG = new BitmapImage();
        DispatcherTimer t = new DispatcherTimer();
        public BitmapImage BG {
            get { return _BG; }
            set { _BG = value; OnPropertyChanged("BG");}
        }
        public double Volume {
            get { return Player.Volume;}
            set { Player.Volume = value; OnPropertyChanged("VolumeChange");}
        }  
        public TimeSpan Duration {
            get {return Player.Duration;}
            set {OnPropertyChanged("duration");}
        }
        public int SelectedIndex {
            get {return _SelectedIndex;} 
            set {
                _SelectedIndex = value;
                Player.IsPlay = false;
                BG = GetBG();
                Player.Open(GetAudio(SelectedIndex));
                OnPropertyChanged("SelectedIndex");
            }
        }
        public double Time {
            get {return Player.Time;}
            set {
                Player.Time = value; 
                OnPropertyChanged("SliderValue");
            }
        }
        public string[] Playlist
        {
            get {return GetPlaylist(); } 
        }
        private string[] GetPlaylist()
        {
            string[] list = new string[Directory.GetDirectories(path).Length];
            int i = 0;
            OsuMap m = new OsuMap("");
            foreach (string dir in Directory.GetDirectories(path))
            {
                m.dir = dir;
                list[i] = (m.Artist + " - " + m.Title);
                i++;
            }
            return list;
        }
        private string GetAudio(int index) 
        {
            OsuMap m = new OsuMap(Directory.GetDirectories(path)[index]);
            return m.dir + "/" + m.Audio.Replace(" ", string.Empty);   
        }
        public BitmapImage GetBG() 
        {
            OsuMap m = new OsuMap(Directory.GetDirectories(path)[SelectedIndex]);
            return new BitmapImage(new System.Uri(m.Background)); 
        }
        private int PlaylistLenght() {return Directory.GetDirectories(path).Length;}
        private void Playsound() {
            if (Player.IsPlay) {
                Player.pause();
                t.Stop();
            }
            else {
                Player.play();
                Time = 0;
                t.Start();
            } 
                
        }
        private void DurSet(object? sender, EventArgs? e) {
            Duration = TimeSpan.Zero;
        }
        private void mediaEnd(object? sender, EventArgs? e) {
            SelectedIndex++;
            Playsound();
        }
        private void timerElapse(object? sender, EventArgs? e) {
            Time+=0;
            Console.WriteLine(Time);
        }

        #endregion

        #region commands
        public ICommand PrevSound {
            get {
                return new DelegateCommand((obj) => { SelectedIndex--; Playsound(); }, (obj) => SelectedIndex > 0 );
            }
        } 
        public ICommand NextSound {
            get {
                return new DelegateCommand((obj) => { SelectedIndex++; Playsound(); }, (obj) => SelectedIndex < PlaylistLenght()-1 );
            }
        } 
        public ICommand PlaySound {
            get {
                return new DelegateCommand((obj) => { Playsound(); } );
            }
        } 
        public ICommand Mute {
            get {
                return new DelegateCommand((obj) => { Player.IsMuted = !Player.IsMuted;}); 
            }
        }

        #endregion
        public MainViewModel() {
            Player = new Sound();
            c = JsonReader.Read("Config.json");
            Volume = c.Volume;
            path = c.Path;
            BG = GetBG();
            t.Tick += new EventHandler(timerElapse);
            t.Interval = TimeSpan.FromSeconds(1);
            Player.Open(GetAudio(SelectedIndex));
            Player.AddOnOpen(new System.EventHandler(DurSet));
            Player.AddOnEnd(new System.EventHandler(mediaEnd));
        }
        
    }
}