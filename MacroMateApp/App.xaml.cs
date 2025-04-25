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
        // Shared view models and services that can be accessed from anywhere in the application  
        public static DailyLogViewModel SharedDailyLogViewModel { get; private set; } = null!;
        public static FoodSearchViewModel SharedFoodSearchViewModel { get; private set; } = null!;
        public static UserGoalsViewModel SharedUserGoalsViewModel { get; private set; } = null!;
        public static INutritionApiService SharedNutritionService { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // initialize shared services  
            SharedNutritionService = new NutritionApiService();

            // initialize shared view models that use Dependency Injection  
            SharedDailyLogViewModel = new DailyLogViewModel();
            SharedFoodSearchViewModel = new FoodSearchViewModel(SharedNutritionService, SharedDailyLogViewModel);
            SharedUserGoalsViewModel = new UserGoalsViewModel(new ApplicationDbContext());
        }
    }
}
