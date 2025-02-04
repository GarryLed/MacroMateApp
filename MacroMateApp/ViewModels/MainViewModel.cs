﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MacroMateApp.Models;

namespace MacroMateApp.ViewModels
{
    public class MainViewModel
    {
        
        // this class is bound to the MainWindow.xaml 
        // handling the data and the users selections 

        // collection to store the food items from the search results using the API 
        public ObservableCollection<FoodItem> FoodSearchResults { get; set; }   


        // collections to store logged food items for each category 
        public ObservableCollection<FoodItem> BreakfastLog {  get; set; } // stores logged food for breakfast 
        public ObservableCollection<FoodItem>LunchLog { get; set; } // stores logged food for lunch                                                             
        public ObservableCollection<FoodItem>DinnerLog { get; set; } // stores logged food for dinner 
        public ObservableCollection<FoodItem>SnacksLog { get; set; } // stores logged food for snacks 

        //store the users selected meal category 
        public string SelectedMealCategory { get; set; } // wll be bound to wpf combo box item 

        // store the users daily goals 
        public UserGoals Goals { get; set; }  


        // store and track daily totals
        public DailyTotals DailyTotals { get; set; }

        
        // Methods 
        // search method 
        private void SearchFoodDatabase()
        {
            // clear the collection before each search
            FoodSearchResults.Clear(); 

            // add food items to collection 

        }


        // adding food to the log method 
        private void LogFoodToCategory(FoodItem food)
        {
            food.Category = SelectedMealCategory; // assign food category to the uses selected food category 

            // check which category was selected by the user 
            switch (SelectedMealCategory)
            {
                case "Breakfast":
                        BreakfastLog.Add(food); // log food to breakfast category 
                    break;
                case "Lunch":
                    LunchLog.Add(food); // log food to breakfast category 
                    break;
                case "Dinner":
                    DinnerLog.Add(food); // log food to breakfast category 
                    break;
                case "Snacks":
                    SnacksLog.Add(food); // log food to breakfast category 
                    break;
            } // end of switch statement 
        }
    }
}
