using System;
using OSU_Player.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace OSU_Player {
    public class ThemeColor2Color : IValueConverter, IDisposable {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var theme = (ThemeColor)value;

            return Color.FromArgb(theme.R, theme.G, theme.B);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return new ThemeColor {R = color.R, G = color.G,B = color.B};
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}