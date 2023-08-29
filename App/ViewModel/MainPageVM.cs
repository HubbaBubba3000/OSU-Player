using System.Collections.Generic;
using OSU_Player.Data;
using System.Linq;

namespace OSU_Player.ViewModel {
    public class MainPageVM : BaseVM {
        public List<Beatmap> list;
        public List<Beatmap> List {
            get {
                return list;
            }
            set {
                this.list = value;
                OnPropertyChanged("ItemsSource");
            }
        }
            
        public MainPageVM(DBParser db) {
            list = db.beatmaps().ToList();
        }
    }
}