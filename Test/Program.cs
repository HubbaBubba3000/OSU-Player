using OSU_Player.Data;
namespace OSU_Player.Test {

    //----------Tests List--------------//
    //AudioEngine - OK
    //ThemeColor - Ok
    //----------------------------------//

    public class Test {


        public static void Main(string[] args) {
            var theme = JsonParser<ThemeConfig>.TryParse("Configs/Theme.json");
            Console.WriteLine(theme.Colors[1].ToString()); 
        }
    }
}