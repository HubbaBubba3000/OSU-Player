using System;
using System.Windows.Input;
using System.IO;
using System.Windows;

namespace OSU_Player.CrashHandler
{
    public partial class CrashWindow : Window
    {

        private string ReadLog() {
            string crashLog = "";
            try {
                crashLog = File.ReadAllBytes("logs.txt").ToString() ?? "logs empty"; 
            }
            catch (Exception e) {
                return $"no logs - {e.ToString()}";
            }
            return crashLog;
        }

        public void Exit(object? sender, RoutedEventArgs e) {
            this.Close();
        }
        public void Report(object? sender, RoutedEventArgs e) {
            MessageBox.Show("Report was arrived");
        }

        public void MoveWindow(object sender, MouseEventArgs e) {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                Window.GetWindow(this).DragMove();
        }

        public CrashWindow(string crashlog = null)
        {
            InitializeComponent();

            textBox.Text = crashlog ?? ReadLog();
        }
    }
}
