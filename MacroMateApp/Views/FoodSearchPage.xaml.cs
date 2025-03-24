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
            //DataContext = new FoodSearchViewModel();
           // DataContext = App.SharedFoodSearchViewModel;
            DataContext = new FoodSearchViewModel(App.SharedDailyLogViewModel);
        }
    }
}
