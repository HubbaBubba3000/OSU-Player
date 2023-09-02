
using OSU_Player.Core;
using OSU_Player.Data;

namespace OSU_Player.ViewModel {
    public class MainWindowVM : BaseVM {

        public HeaderVM header {get; set;}
        public ControlPanelVM control {get; set;}
        public MainPageVM page {get; set;}
        public MainWindowVM(DBParser db, Player player) {
            header = new HeaderVM();
            control = new ControlPanelVM(player);
            page = new MainPageVM(db, player);

        }
        
    }
}