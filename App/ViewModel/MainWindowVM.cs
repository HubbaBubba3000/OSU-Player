
using OSU_Player.Core;
using OSU_Player.Data;

namespace OSU_Player.ViewModel {
    public class MainWindowVM : BaseVM {

         HeaderVM header {get; set;}
         ControlPanelVM control {get; set;}
         MainPageVM page {get; set;}
        public MainWindowVM(DBParser db, Player player) {
            header = new HeaderVM();
            control = new ControlPanelVM(player);
            page = new MainPageVM(db, player);

        }
        
    }
}