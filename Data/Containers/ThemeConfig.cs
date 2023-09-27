

namespace OSU_Player.Data {

    public class ThemeConfig : IConfig {
        public ThemeColor[]? Colors {get;set;}

        public static ThemeConfig Default => new ThemeConfig() {
            Colors = new ThemeColor[] {
                new ThemeColor{R=0, G=123, B=123},
                new ThemeColor{R=0, G=123, B=123},
                new ThemeColor{R=0, G=123, B=123},
                new ThemeColor{R=0, G=123, B=123}
            }
        };
    }
}