using System.Linq;
using System.Windows;
using MacroMateApp.Data;
using MacroMateApp.Models;
using MacroMateApp.Services;
using MacroMateApp.ViewModels;

namespace MacroMateApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Shared view models and services
        public static DailyLogViewModel SharedDailyLogViewModel { get; private set; }
        public static FoodSearchViewModel SharedFoodSearchViewModel { get; private set; }
        public static UserGoalsViewModel SharedUserGoalsViewModel { get; private set; }

        public static INutritionApiService SharedNutritionService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // initialize shared services
            SharedNutritionService = new NutritionApiService();

            // initialize shared view models that uses Dependency Injection
            SharedDailyLogViewModel = new DailyLogViewModel();
            SharedFoodSearchViewModel = new FoodSearchViewModel(SharedNutritionService, SharedDailyLogViewModel);
            SharedUserGoalsViewModel = new UserGoalsViewModel(new ApplicationDbContext());

            // settting default goals for testing 
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

        }
    }
}
