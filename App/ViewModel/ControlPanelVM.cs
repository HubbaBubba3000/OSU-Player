using OSU_Player.Core;
using System.Windows.Input;
namespace OSU_Player.ViewModel {
    public class ControlPanelVM : BaseVM {
        CoreBass bass;
        public ControlPanelVM() {
            bass = new CoreBass();
        }

        public ICommand Play {
            get {
                return new RelayCommand((obj) => { bass.Run(); });
            }
        }
    }
}