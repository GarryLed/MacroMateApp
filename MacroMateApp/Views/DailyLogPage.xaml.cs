using System.Windows.Controls;
using System.Windows.Input;
using MacroMateApp.Views;
using MacroMateApp.ViewModels;

namespace MacroMateApp.Views
{
    /// <summary>
    /// Interaction logic for DailyLogPage.xaml
    /// </summary>
    public partial class DailyLogPage : Page
    {
        // Commands for navigation
        public ICommand NavigateToFoodSearchCommand { get; }
        public ICommand NavigateToGoalsCommand { get; }

        public DailyLogPage()
        {
            InitializeComponent();

            // Setup navigation command for food search and goals
            NavigateToFoodSearchCommand = new RelayCommand(() =>
            {
                NavigationService?.Navigate(new FoodSearchPage()); // food search page
            });

            NavigateToGoalsCommand = new RelayCommand(() =>
            {
                NavigationService?.Navigate(new GoalsPage()); // goals page
            });

            // Combine navigation and log view model into composite DataContext object
            DataContext = new
            {
                NavigateToFoodSearchCommand,
                NavigateToGoalsCommand,
                LogVM = App.SharedDailyLogViewModel
            };
        }
    }
}
