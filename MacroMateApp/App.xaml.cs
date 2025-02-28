using System.Configuration;
using System.Data;
using System.Windows;
using MacroMateApp.ViewModels;
using MacroMateApp.Views;

namespace MacroMateApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Sharing the DailyLogViewModel accross the app  and initilizing a new instance of the DailyLogViewModel 
        public static DailyLogViewModel SharedDailyLogViewModel { get; private set; } = new DailyLogViewModel();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
           MainWindow mainWindow = new MainWindow();
           mainWindow.Show();

            

            
        }
    }

}
