
using OSU_Player.Core;
using OSU_Player.Data;

namespace OSU_Player.ViewModel {
    public class MainWindowVM : BaseVM {

        public HeaderVM header {get; set;}
        public  ControlPanelVM control {get; set;}
        public  MainPageVM page {get; set;}
        public MainWindowVM(HeaderVM header, ControlPanelVM control, MainPageVM page) {
            this.control = control;
            this.header = header;
            this.page = page;
        }
        
    }
}