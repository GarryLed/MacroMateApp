using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using MacroMateApp.Data;
using MacroMateApp.Models;
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
        public static DailyLogViewModel SharedDailyLogViewModel { get; private set; } //= new DailyLogViewModel();
        public static FoodSearchViewModel SharedFoodSearchViewModel { get; private set; } //= new FoodSearchViewModel();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();


            SharedDailyLogViewModel = new DailyLogViewModel();
            SharedFoodSearchViewModel = new FoodSearchViewModel(SharedDailyLogViewModel);


            // testing database connection for UserGoals
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated(); 

                if (!db.UserGoals.Any())
                {
                    db.UserGoals.Add(new UserGoals
                    {
                        CaloriesGoal = 2000,
                        ProteinGoal = 150,
                        CarbGoal = 250,
                        FatGoal = 70
                    });
                    db.SaveChanges();
                }

                var testGoal = db.UserGoals.FirstOrDefault();
                MessageBox.Show($"Test Goal: {testGoal?.CaloriesGoal} kcal");
            }

            // testing database connection for FoodItem
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated(); 

                if (!db.FoodLog.Any())
                {
                    db.FoodLog.Add(new FoodItem
                    {
                        Name = "Grilled Chicken Breast",
                        Calories = 165,
                        Protein = 31,
                        Carbs = 0,
                        Fats = 4,
                        ImageUrl = "random image url"
                    });
                    db.SaveChanges();
                    MessageBox.Show("Food item saved!");
                }
            }

        }



    }

}
