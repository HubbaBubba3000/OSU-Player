using System.Windows.Controls;
using System.Windows;
using OSU_Player.Data;
using System.Windows.Media;
using System.Globalization;
using System;

namespace OSU_Player {
    public class DataColors{
            public Color C1 {get; set;}
            public Color C2 {get; set;}
            public Color C3 {get; set;}
            public Color C4 {get; set;}
            public Color C5 {get; set;}
        public DataColors() {

            var theme = JsonParser<ThemeConfig>.TryParse("Configs/Theme.json")?.Colors;
            
                C1 = (Color)ColorConverter.ConvertFromString(theme[0]);
                C2 = (Color)ColorConverter.ConvertFromString(theme[1]);
                C3 = (Color)ColorConverter.ConvertFromString(theme[2]);
                C4 = (Color)ColorConverter.ConvertFromString(theme[3]);
                C5 = (Color)ColorConverter.ConvertFromString(theme[4]);
        }
    }
}