using Coosu.Database.Serialization;
using System.IO;

namespace OSU_Player.Data {
    public class DBParser : IDisposable{
        OsuDb osuDb;
        readonly string path;
        public DBParser() {
            this.path = JsonParser<DefaultConfig>.TryParse("Configs\\Default.json").OsuFolder;
            osuDb = OsuDb.ReadFromFile(path + "/osu!.db");
        }

        string fol(Coosu.Database.DataTypes.Beatmap b) {
            return (b.FolderName.EndsWith(" ") ? b.FolderName.Remove(b.FolderName.Length-1) : b.FolderName);
        }
        
        public Beatmap BeatmapConverter(Coosu.Database.DataTypes.Beatmap b) {
            return new Beatmap() {
                Artist = b.Artist,
                FileName = b.FileName,
                length = b.DrainTime.Milliseconds,
                FolderPath = Path.Combine(path,"Songs", fol(b) ),
                Name = b.Title,
                AudioFile = Path.Combine(path,"Songs", fol(b), b.AudioFileName)
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