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
    /// Interaction logic for GoalsPage.xaml
    /// </summary>
    public partial class GoalsPage : Page
    {
        public GoalsPage()
        {
            InitializeComponent();
            DataContext = new UserGoalsViewModel();
        }
    }
}
