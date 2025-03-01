using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using MacroMateApp.Data;
using MacroMateApp.ViewModels;
using MacroMateApp.Views;
using Microsoft.EntityFrameworkCore;

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

            // testing database connection 
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Database.Migrate(); // apply a migration at each startup 
                    var testConnection = db.Database.CanConnect(); // used to determine if the database is available and can be connected to 

                    // check if connection is successful 
                    if (testConnection)
                    {
                        Debug.WriteLine("Database connection is successful"); // I can see in the debug window if the database connects succefully 
                    }
                    else
                    {
                        Debug.WriteLine("Database connection failed");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Database error: {ex.Message}");
            }

            
        }
    }

}
