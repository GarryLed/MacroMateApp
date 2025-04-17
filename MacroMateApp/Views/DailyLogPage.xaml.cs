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
        public ICommand NavigateToFoodSearchCommand { get; }
        public ICommand NavigateToGoalsCommand { get; }

        public DailyLogPage()
        {
            InitializeComponent();

            // Setup navigation commands
            NavigateToFoodSearchCommand = new RelayCommand(() =>
            {
                NavigationService?.Navigate(new FoodSearchPage());
            });

            NavigateToGoalsCommand = new RelayCommand(() =>
            {
                NavigationService?.Navigate(new GoalsPage());
            });

            // Combine navigation + log view model into composite DataContext
            DataContext = new
            {
                NavigateToFoodSearchCommand,
                NavigateToGoalsCommand,
                LogVM = App.SharedDailyLogViewModel
            };
        }
    }
}
