using System;
using OSU_Player.Data;

namespace OSU_Player.ViewModel {
    public class MainWindowVM : BaseVM {

        public HeaderVM header {get; set;}
        public ControlPanelVM control {get; set;}
        public MainPageVM page {get; set;}
        public MainWindowVM(DBParser db) {
            header = new HeaderVM();
            control = new ControlPanelVM();
            page = new MainPageVM(db);

        }
        
    }
}