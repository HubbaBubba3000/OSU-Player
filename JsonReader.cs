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
        public string C1 { get;set;}= "";
        public string C2 { get;set;}= "";
        public string C3 { get;set;}= "";
        public string C4 { get;set;}= "";
        public string Path { get;set;}= "";
        public double Volume { get;set;}

    }
}