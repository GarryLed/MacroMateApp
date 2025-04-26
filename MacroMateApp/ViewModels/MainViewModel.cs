using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MacroMateApp.Models;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using MacroMateApp.Views;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;



namespace MacroMateApp.ViewModels
{
    public class MainViewModel
    {
        
        #region Navigation 
        
        public ICommand NavigateToHomeCommand { get; private set; }
        public ICommand NavigateToFoodSearchCommand { get; private set; }
        public ICommand NavigateToDailyLogCommand { get; private set; }
        public ICommand NavigateToGoalsCommand { get; private set; }
        public ICommand NavigateToSettingsCommand { get; private set;  }



        public MainViewModel() 
        {
            // create a new instance of the RelayCommand class and pass in "nav method as parameters 
            NavigateToHomeCommand = new RelayCommand(NavigateToHomePage); // no canExecute is provided so this buttion is always enabled (same for the buttons below)
            NavigateToFoodSearchCommand = new RelayCommand(NavigateToFoodSearchPage);
            NavigateToDailyLogCommand = new RelayCommand(NavigateToDailyLogPage);
            NavigateToGoalsCommand = new RelayCommand(NavigateToGoalsPage);
            
        }
        // Nav methods 

        // navigate to home page 
        private void NavigateToHomePage()
        {
            NavigateToPage(new HomePage());
        }

        // navigate to food search page 
        private void NavigateToFoodSearchPage()
        {
            NavigateToPage(new FoodSearchPage());
        }

        // navigate to daily log page 
        private void NavigateToDailyLogPage()
        {
            NavigateToPage(new DailyLogPage());
        }

        // navigate to goals page 
        private void NavigateToGoalsPage()
        {
            NavigateToPage(new GoalsPage());
        }

        // 
        private void NavigateToPage(Page page)
        {
            // checks if the current window is the mainWindow
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                // 
                mainWindow.MainFrame.NavigationService.Navigate(page);
            }
            else
            {
                MessageBox.Show("Error! Page not found");
            }
        }

        #endregion
       
    }
}
