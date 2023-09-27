using System.Windows.Controls;
using System.Windows;
using OSU_Player.Data;
using System.Windows.Media;
using System.Globalization;
using System;

namespace OSU_Player {
    public partial class ResourceColors : ResourceDictionary {
            public Color C1 {get; set;}
            public Color C2 {get; set;}
            public Color C3 {get; set;}
            public Color C4 {get; set;}
            public Color C5 {get; set;}
        public ResourceColors() {

            var theme = JsonParser<ThemeConfig>.TryParse("Configs/Theme.json")?.Colors;

            C1 = Color.FromArgb(0xFF,(byte)theme[0].R, (byte)theme[0].G, (byte)theme[0].B);
            C2 = Color.FromArgb(0xFF,(byte)theme[1].R, (byte)theme[1].G, (byte)theme[1].B);
            C3 = Color.FromArgb(0xFF,(byte)theme[2].R, (byte)theme[2].G, (byte)theme[2].B);
            C4 = Color.FromArgb(0xFF,(byte)theme[3].R, (byte)theme[3].G, (byte)theme[3].B);
            C5 = Color.FromArgb(0xFF,(byte)theme[4].R, (byte)theme[4].G, (byte)theme[4].B);
        }
    }
}