using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;


namespace OSU_Player
{
    public partial class MainWindow : Window
    {
        string path = "D:/OSU!/Songs/";
        public MainWindow()
        {
            InitializeComponent();
            Playlist.ItemsSource = GetPlaylist(); 
        }

        public void WindowMove(Object sender, MouseEventArgs a) 
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        public void WindowClose(Object sender, RoutedEventArgs e) 
        {
            this.Close();
        }

        public List<string> GetPlaylist()
        {
            int ldir = Directory.GetDirectories(path).Length;
            List<string> r = new List<string>(ldir);
            foreach (string dir in Directory.GetDirectories(path))
            {
                 r.Add(dir.Remove(0, path.Length + 6));
            }
            return r;
        }
    }
}
