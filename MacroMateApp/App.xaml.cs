using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
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
        // Shared view models
        public static DailyLogViewModel SharedDailyLogViewModel { get; private set; }
        public static FoodSearchViewModel SharedFoodSearchViewModel { get; private set; }
        public static UserGoalsViewModel SharedUserGoalsViewModel { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize shared view models
            SharedDailyLogViewModel = new DailyLogViewModel();
            SharedFoodSearchViewModel = new FoodSearchViewModel(SharedDailyLogViewModel);
            SharedUserGoalsViewModel = new UserGoalsViewModel();

            // Ensure UserGoals exist in DB
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

            // Ensure sample FoodItem exists
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
