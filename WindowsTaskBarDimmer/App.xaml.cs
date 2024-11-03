using System.Configuration;
using System.Data;
using System.Windows;

namespace WindowsTaskBarDimmer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var displayHeight = SystemParameters.PrimaryScreenHeight;
            var appHeight = mainWindow.Height;
            mainWindow.Top = displayHeight - appHeight - 70;
            mainWindow.ShowDialog();
        }
    }

}