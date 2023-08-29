using System;
using System.Windows;
using OSU_Player.Data;
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
                DefaultConfig defaultconfig = JsonParser<DefaultConfig>.TryParse("Configs/Default.json");
               // var defaultconfig = DefaultConfig.Default;
                DBParser db = new DBParser(defaultconfig.OsuFolder);

                window = new MainWindow() {DataContext = new MainWindowVM(db)};
            }
            catch (Exception exception) {
               window = new CrashWindow(exception.Message + exception.Source);
                
            }

            window.Show();
            
        }

    }
}
