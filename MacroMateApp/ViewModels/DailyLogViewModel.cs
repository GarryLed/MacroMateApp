using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MacroMateApp.Models;
using System.Windows.Input;

namespace MacroMateApp.ViewModels
{
    // a class to handle the business logic for the DailyLogs 
    public class DailyLogViewModel
    {
        // properties for storing food items in relevant categories 
        public ObservableCollection<FoodItem> BreakfastLog { get; set; } = new();
        public ObservableCollection<FoodItem> LunchLog { get; set; } = new();
        public ObservableCollection<FoodItem> DinnerLog { get; set; } = new();
        public ObservableCollection<FoodItem> SnacksLog { get; set; } = new();

        // Using ICommand for button event handling 
        public ICommand DeleteItemCommand { get; private set; }
        public ICommand ClearDailyLogCommand { get; private set; }

        // properties for calculating daily totals 

        // calculate total calories 
        public int TotalCalories => BreakfastLog.Sum(t => t.Calories) + LunchLog.Sum(t => t.Calories) 
                                    + DinnerLog.Sum(t => t.Calories) + SnacksLog.Sum(t => t.Calories);

        // calculate total protein 
        public int TotalProtein => BreakfastLog.Sum(t =>t.Protein) + LunchLog.Sum(t => t.Protein)
                                    + DinnerLog.Sum(t => t.Protein) + SnacksLog.Sum(t => t.Protein);

        // calculate total carbs 
        public int TotalCarbs => BreakfastLog.Sum(t => t.Carbs) + LunchLog.Sum(t => t.Carbs)
                                    + DinnerLog.Sum(t => t.Carbs) + SnacksLog.Sum(t => t.Carbs);

        // calculate total fats 
        public int TotalFats => BreakfastLog.Sum(t => t.Fats) + LunchLog.Sum (t => t.Fats)
                                + DinnerLog.Sum(t => t.Fats) + SnacksLog.Sum(t => t.Fats);
                                                  

        // constructor 
        public DailyLogViewModel()
        {
            // Test data for Breakfast 
            BreakfastLog = new ObservableCollection<FoodItem>
            {
                new FoodItem {Name = "Oatmeal", Calories = 150, Protein = 10, Carbs = 10, Fats = 4 },
                new FoodItem {Name = "Milk", Calories = 110, Protein = 6, Carbs = 3, Fats = 3}

            };
            // Binding commands for deleting food items 
            DeleteItemCommand = new RelayCommand<FoodItem>(DeleteItem);

        }

        // methods 
        // delete a food item 
        private void DeleteItem(FoodItem item)
        {
            BreakfastLog.Remove(item); // removes item from BreakfastLog 
            LunchLog.Remove(item); // removes item form LuchLog 
            DinnerLog.Remove(item); // removes item form DinnerLog 
            SnacksLog.Remove(item); // removes item from SnacksLog 
        }

        // clear the daily food log 
        // will remove all food items from collections 
        private void ClearDailyLog()
        {
            BreakfastLog.Clear();
            LunchLog.Clear();
            DinnerLog.Clear();
            SnacksLog.Clear();
        }
    }
}
