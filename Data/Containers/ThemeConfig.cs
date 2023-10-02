

namespace OSU_Player.Data {

    public class ThemeConfig : IConfig {
        public string[]? Colors {get;set;}

        public static ThemeConfig Default => new ThemeConfig() {
            Colors = new string[5] {
                "#000000",
                "#000000",
                "#000000",
                "#000000",
                "#000000"
            }
        };

    }
}