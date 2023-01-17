using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace OSU_Player
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
