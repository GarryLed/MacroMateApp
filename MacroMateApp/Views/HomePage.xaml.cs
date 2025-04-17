using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MacroMateApp.ViewModels;

namespace MacroMateApp.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            // Set DataContext with the expected properties
            DataContext = new
            {
                GoalsVM = App.SharedUserGoalsViewModel,
                LogVM = App.SharedDailyLogViewModel,
                NavigateFoodSearchCommand = new RelayCommand(() =>
                {
                    NavigationService?.Navigate(new FoodSearchPage());
                }),
                NavigateDailyLogCommand = new RelayCommand(() =>
                {
                    NavigationService?.Navigate(new DailyLogPage());
                })
            };
        }
    }
}
