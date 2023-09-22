using OSU_Player.Core;
using System.Windows.Input;
namespace OSU_Player.ViewModel {
    public class ControlPanelVM : BaseVM {
        Player player;
        public ControlPanelVM(Player player) {
            this.player = player;
        }

        public int Volume {
            get {
                return player.audioEngine.Volume;
            }
            set {
                player.audioEngine.Volume = value;
                OnPropertyChanged("Volume");
            }
        }

        public ICommand TooglePlayAndPause {
            get {
                return new RelayCommand((obj) => { player.TooglePlayAndPause(); });
            }
        }
    }
}