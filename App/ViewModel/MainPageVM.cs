using System.Collections.Generic;
using OSU_Player.Data;
using OSU_Player.Core;
using System.Linq;

namespace OSU_Player.ViewModel {
    public class MainPageVM : BaseVM {
        Player player;
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
        public Beatmap Current {
            get {
                return player.currentBeatmap;
            }
            set {
                player.currentBeatmap = value;
                OnPropertyChanged("SelectedItem");
            }
        
        }
            
        public MainPageVM(DBParser db, Player player) {
            list = db.beatmaps().ToList();
            this.player = player;
        }
    }
}