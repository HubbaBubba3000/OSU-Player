using System;
using System.Windows;
using OSU_Player.Data;
using OSU_Player.Core;
using OSU_Player.ViewModel;
using OSU_Player.CrashHandler;

namespace OSU_Player
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object? sender, StartupEventArgs e) {
            Window window;

            try {
                var defaultconfig = JsonParser<DefaultConfig>.TryParse("Configs/Default.json");
                AudioEngine audioEngine = new AudioEngine();
                DBParser db = new DBParser(defaultconfig.OsuFolder);
                Player player = new Player(audioEngine, defaultconfig);
                window = new MainWindow() {DataContext = new MainWindowVM(db, audioEngine, player)};
                window.Show();
            }
            catch (Exception exception) {
                window = new CrashWindow(exception.Message + " " + exception.Source);
                window.Show();
            }

        }

    }
}
