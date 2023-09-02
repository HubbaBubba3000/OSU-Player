using OSU_Player.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace OSU_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowVM mainvm)
        {
            DataContext = mainvm;
            InitializeComponent();
        }


    }
}
