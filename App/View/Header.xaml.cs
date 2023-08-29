
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OSU_Player.View {
    public partial class Header : UserControl {
        public Header() {
            InitializeComponent();
        }
        public void ButtonExit(object? sender, RoutedEventArgs e) {
            Window.GetWindow(this).Close();
        }
        public void ButtonCut(object? sender, RoutedEventArgs e) {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }
        public void ButtonMiniPlayer(object? sender, RoutedEventArgs e) {
            //Todo Make MiniPlayer
        }


        public void MoveWindow(object sender, MouseEventArgs e) {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                Window.GetWindow(this).DragMove();
        }
    }
}