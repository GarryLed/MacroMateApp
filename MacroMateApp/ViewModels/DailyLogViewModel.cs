using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MacroMateApp.Models;

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

        // methods 

    }
}
