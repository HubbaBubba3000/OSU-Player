using System.Text.Json;
using System.IO;

namespace OSU_Player.Data {
    public class JsonParser<TConfig> where TConfig : IConfig {

        private static string jsonread(string file) {
            using (var filestream = new StreamReader(file) ) {
                var json = filestream.ReadToEnd();
                return json;
            }
        }
        public static TConfig? Parse(string conf) {
            return JsonSerializer.Deserialize<TConfig>(jsonread(conf));
        }
        public static TConfig? TryParse (string conf) {
            try {
                var json = JsonSerializer.Deserialize<TConfig>(jsonread(conf));
                return json;
            }
            catch (Exception e) {
                Console.WriteLine("e- " + e.Message);
                Console.WriteLine("conf- " + conf);
                return (TConfig)IConfig.Default;
            }
        }

        public void Dispose() {
            // dispose
        }
    }
}