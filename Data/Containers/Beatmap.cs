
namespace OSU_Player.Data {
    public class Beatmap : IBeatmap {
        public string Artist {get; set;} = string.Empty;

        public string Name {get; set;} = string.Empty;

        public int length {get; set;} = 0;

        public string FileName {get; set;} = string.Empty;
        public string AudioFile {get; set;} = string.Empty;

        public string FolderPath {get; set;} = string.Empty;
    }
}