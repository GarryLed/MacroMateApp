using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MacroMateApp.Models;
using System.Windows.Input;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MacroMateApp.ViewModels
{
    // a class to handle the business logic for the DailyLogs 
    public class DailyLogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;  

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // properties for storing food items in relevant categories 
        public ObservableCollection<FoodItem> BreakfastLog { get; set; } = new();
        public ObservableCollection<FoodItem> LunchLog { get; set; } = new();
        public ObservableCollection<FoodItem> DinnerLog { get; set; } = new();
        public ObservableCollection<FoodItem> SnacksLog { get; set; } = new();

        // Using ICommand for button event handling 
        public ICommand DeleteItemCommand { get; }
        public ICommand ClearDailyLogCommand { get; }

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

            // Test data for Lunch 
            LunchLog = new ObservableCollection<FoodItem>
            {
                new FoodItem { Name = "Grilled Chicken", Calories = 200, Protein = 30, Carbs = 0, Fats = 5 },
                new FoodItem { Name = "Brown Rice", Calories = 216, Protein = 5, Carbs = 45, Fats = 2 }
            };

                    // Test data for Dinner
                    DinnerLog = new ObservableCollection<FoodItem>
            {
                new FoodItem { Name = "Salmon", Calories = 250, Protein = 22, Carbs = 0, Fats = 15 },
                new FoodItem { Name = "Steamed Broccoli", Calories = 55, Protein = 4, Carbs = 11, Fats = 0 }
            };

                    // Test data for Snacks
                    SnacksLog = new ObservableCollection<FoodItem>
            {
                new FoodItem { Name = "Greek Yogurt", Calories = 100, Protein = 10, Carbs = 6, Fats = 0 },
                new FoodItem { Name = "Almonds", Calories = 170, Protein = 6, Carbs = 6, Fats = 15 }
            };
                    // Binding commands for deleting food items 
                    DeleteItemCommand = new RelayCommand<FoodItem>(DeleteItem);

                    ClearDailyLogCommand = new RelayCommand(ClearDailyLog);

        }

        // methods 
        // delete a food item 
        private void DeleteItem(FoodItem item)
        {
            BreakfastLog.Remove(item); // removes item from BreakfastLog 
            LunchLog.Remove(item); // removes item form LuchLog 
            DinnerLog.Remove(item); // removes item form DinnerLog 
            SnacksLog.Remove(item); // removes item from SnacksLog 

            // notify the ui to update total 
            OnPropertyChanged(nameof(TotalCalories)); 
            OnPropertyChanged(nameof(TotalProtein));
            OnPropertyChanged(nameof(TotalCarbs));
            OnPropertyChanged(nameof(TotalFats));
        }

        // clear the daily food log 
        // will remove all food items from collections 
        private void ClearDailyLog()
        {
            BreakfastLog.Clear();
            LunchLog.Clear();
            DinnerLog.Clear();
            SnacksLog.Clear();

            // notify the ui to update total 
            OnPropertyChanged(nameof(TotalCalories));
            OnPropertyChanged(nameof(TotalProtein));
            OnPropertyChanged(nameof(TotalCarbs));
            OnPropertyChanged(nameof(TotalFats));
        }
    }
}
