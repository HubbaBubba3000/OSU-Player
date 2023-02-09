using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace OSU_Player
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var start = new Stopwatch();
            start.Start();
            InitializeComponent();
            Console.WriteLine(start.ElapsedMilliseconds);
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

    }
}
