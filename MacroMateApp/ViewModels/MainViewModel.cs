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
            NavigateToSettingsCommand = new RelayCommand(NavigateToSettingsPage);
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

        // navigate to settings page
        private void NavigateToSettingsPage()
        {
            NavigateToPage(new SettingsPage());
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
        // this class is bound to the MainWindow.xaml 
        // handling the data and the users selections 

        // collection to store the food items from the search results using the API 
        /*
        public ObservableCollection<FoodItem> FoodSearchResults { get; set; }   


        // collections to store logged food items for each category 
        public ObservableCollection<FoodItem> BreakfastLog {  get; set; } // stores logged food for breakfast 
        public ObservableCollection<FoodItem>LunchLog { get; set; } // stores logged food for lunch                                                             
        public ObservableCollection<FoodItem>DinnerLog { get; set; } // stores logged food for dinner 
        public ObservableCollection<FoodItem>SnacksLog { get; set; } // stores logged food for snacks 

        //store the users selected meal category 
        public string SelectedMealCategory { get; set; } // wll be bound to wpf combo box item 

        // store the users daily goals 
        public UserGoals Goals { get; set; }  // Composition relationship 


        // store and track daily totals
        public DailyTotals DailyTotals { get; set; } // composition relationship 
   */
    }
}
