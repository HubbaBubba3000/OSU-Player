using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OSU_Player
{
    public class OsuMap {
        public string dir = string.Empty;
        public string Title {get => Parse("Title");}
        public string Artist {get => Parse("Artist");}
        public string Audio {get => Parse("AudioFilename");}
        public string Background {get => GetBG();}
        public string Parse(string p) {
            var file = Directory.EnumerateFiles(dir, "*.osu", 0).ElementAt(0);
            ReadOnlySpan<char> line;
            using (FileStream fs = File.Open(file, FileMode.Open))
            using (BufferedStream bf = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bf)) {
                while (!sr.EndOfStream) {
                    line = sr.ReadLine();
                    if (line.StartsWith(p)) {
                        sr.Close();
                        return line.Slice(p.Length+1).ToString();
                    }
                }
                return "err";
            }
        }
        private string GetBG() {
            string[] filters = new String[] { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.tiff", "*.bmp", "*.svg" };
            foreach (string filt in filters)
            {
                if (Directory.GetFiles(dir,filt).Length > 0) 
                    return Directory.EnumerateFiles(dir,filt).ElementAt(0);
            }
            return string.Empty;
        }
        public OsuMap(string dir) {
            this.dir = dir;
        }
    }
}