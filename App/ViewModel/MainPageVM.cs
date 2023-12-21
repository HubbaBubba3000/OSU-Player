using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.IO;
using OSU_Player.Data;
using OSU_Player.Core;
using System.Linq;
using System;


namespace OSU_Player.ViewModel {
    public class MainPageVM : BaseVM {
        Player player;
        public List<Beatmap> list;
        public BitmapImage BG;
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
                Background = new BitmapImage( new Uri( GetBG(value.FolderPath), UriKind.Relative));
                OnPropertyChanged("SelectedItem");
            }
        
        }

        public BitmapImage Background {
            get {
                return BG;
            }
            set {
                BG = value;
                OnPropertyChanged("Background");
            }
        } 

        private string GetBG(string FolderPath) {
            
            var eventCount = 0;

            string[] files;

            files = Directory.GetFiles(FolderPath, "*.osu");

            if (files.Length == 0)
                return null;
            if (files[0].Length > 260)
                return null;

            var content = File.ReadAllLines(files[0]);

            foreach (var s in content)
            {
                if (s.Equals("[Events]")) break;

                eventCount++;
            }

            var background = string.Empty;

            for (var e = 1; e < 6; e++)
                if (content[eventCount + e].ToLower().Contains(".jpg") ||
                    content[eventCount + e].ToLower().Contains(".png"))
                {
                    background = content[eventCount + e];
                    break;
                }

            if (string.IsNullOrEmpty(background))
                return null;

            var fileName = background.Split(',')[2].Replace("\"", string.Empty);
            var path = Path.Combine(FolderPath, fileName);

            return File.Exists(path) ? path : null;

        }

        public MainPageVM(DBParser db, Player player) {
            list = db.beatmaps().ToList();
            this.player = player;
            Background = new BitmapImage( new Uri( GetBG(list[0].FolderPath), UriKind.Relative));
            this.player.currentBeatmap = list[0];
            var c = JsonParser<DefaultConfig>.TryParse("../App/Configs/Default.json");
            this.player.audioEngine.CreateStream(Path.Combine(Current.FolderPath, Current.AudioFile), c.Volume);
        }
    }
}