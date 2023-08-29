using Coosu.Database.Serialization;
using System.IO;

namespace OSU_Player.Data {
    public class DBParser : IDisposable{
        OsuDb osuDb;
        readonly string path;
        public DBParser(string path) {
            this.path = path;
            osuDb = OsuDb.ReadFromFile(path + "/osu!.db");
        }
        
        public Beatmap BeatmapConverter(Coosu.Database.DataTypes.Beatmap b) {
            return new Beatmap() {
                Artist = b.Artist,
                FileName = b.FileName,
                length = b.DrainTime.Milliseconds,
                FolderPath = path + b.FolderName,
                Name = b.Title
            };
        }

        public IEnumerable<Beatmap> beatmaps() {
            string folder = "";
            foreach (var b in osuDb.Beatmaps) {
                if (folder == b.FolderName) 
                    continue;
                folder = b.FolderName;
                yield return BeatmapConverter(b);
            }  
        }

        public int BeatmapCount() {
            return osuDb.FolderCount;
        }
 
        public void Dispose()
        {
            osuDb = null;
            GC.SuppressFinalize(this);
        }
    }
}