
namespace OSU_Player.Data {
    public class DefaultConfig : IConfig
    {
        public string OsuFolder {get;set;}
        public int Volume {get;set;}
        // public bool Repeat;

        public static DefaultConfig Default => new DefaultConfig() {
            OsuFolder = "D:/osu!",
            Volume = 1000
        };
    }
}