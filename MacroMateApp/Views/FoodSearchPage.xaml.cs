using MacroMateApp.ViewModels;
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

namespace MacroMateApp.Views
{
    /// <summary>
    /// Interaction logic for FoodSearchPage.xaml
    /// </summary>
    public partial class FoodSearchPage : Page
    {
        public FoodSearchPage()
        {
            InitializeComponent();

            // using the Shared NutritionService and DailyLogViewModel to create a new instance of the FoodSearchViewModel for the data context
            // this allows for Dependency Injection and decouples the view model from the service
            DataContext = new FoodSearchViewModel(App.SharedNutritionService, App.SharedDailyLogViewModel);

        }
    }
}
