using System.IO;
using System;
using System.Text.Json;

namespace OSU_Player.Json {
    static class JsonReader {
        public static Config? Read(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open)) 
            {
                return JsonSerializer.Deserialize<Config>(fs);
            }
        }
    }
    class Config {
        public string Path { get;set;}= "";
        public double Volume { get;set;}

    }
}