using System;
using System.Windows;
using OSU_Player.Data;
using OSU_Player.Core;
using OSU_Player.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace OSU_Player
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IHost host;
        public App() {
            host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices( service => {

                    service.AddSingleton<AudioEngine>();
                    service.AddSingleton<DBParser>();
                    service.AddSingleton<Player>();

                    service.AddSingleton<MainWindowVM>();

                    service.AddSingleton<MainWindow>();
                })
                .ConfigureLogging (logging => {
                    logging.AddEventLog();
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                ;
        }
        private void OnStartup(object? sender, StartupEventArgs e) {
            
            host.Start();

            Window? window = host.Services.GetService<MainWindow>();
            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.StopAsync();
            host.Dispose();

            base.OnExit(e);
        }

    }
}
