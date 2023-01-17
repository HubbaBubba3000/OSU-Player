using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace OSU_Player.ViewModel
{
    public class BaseVM : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel : BaseVM
    {
       #region properties
        string path = "D:/OSU!/Songs/";
        private int _SelectedIndex;
        public int SelectedIndex {
            get {return _SelectedIndex;} 
            set
            {
                _SelectedIndex = value;
                OnPropertyChanged("SelectedIndex");
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
            foreach (string dir in Directory.GetDirectories(path))
            {
                OsuMap m = new OsuMap(dir);
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
        private int PlaylistLenght() {return Directory.GetDirectories(path).Length;}
        private void Playsound() {
            var player = new Sound(GetAudio(SelectedIndex));
            player.play();
        }

        #endregion

        #region commands
        public ICommand PrevSound {
            get {
                return new DelegateCommand((obj) => { SelectedIndex--; }, (obj) => SelectedIndex > 0 );
            }
        } 
        public ICommand NextSound {
            get {
                return new DelegateCommand((obj) => { SelectedIndex++; }, (obj) => SelectedIndex < PlaylistLenght()-1 );
            }
        } 
        public ICommand PlaySound {
            get {
                return new DelegateCommand((obj) => { Playsound(); } );
            }
        } 

        #endregion
        public MainViewModel() {
        }
        
    }
}