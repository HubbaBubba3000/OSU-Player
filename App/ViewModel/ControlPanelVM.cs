using OSU_Player.Core;
using System.Windows.Input;
namespace OSU_Player.ViewModel {
    public class ControlPanelVM : BaseVM {
        AudioEngine audioEngine;
        Player player;
        public ControlPanelVM(AudioEngine ae, Player player) {
            audioEngine = ae;
            this.player = player;
        }

        public ICommand TooglePlayAndPause {
            get {
                return new RelayCommand((obj) => { player.TooglePlayAndPause(); });
            }
        }
    }
}