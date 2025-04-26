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
using MacroMateApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MacroMateApp.ViewModels
{
    // a class to handle the business logic for the DailyLogs 
    public class DailyLogViewModel : INotifyPropertyChanged
    {
        private readonly ApplicationDbContext _db = new(); // database context for accessing the database

        // PropertyChanged event for data binding
        public event PropertyChangedEventHandler? PropertyChanged;

        // method to notify the UI when a property changes 
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // creating a new instance of the DailyTotals class 
        public DailyTotals DailyTotals { get; set; } = new();


        // properties for storing food items in relevant categories 
        public ObservableCollection<FoodItem> BreakfastLog { get; set; } = new();
        public ObservableCollection<FoodItem> LunchLog { get; set; } = new();
        public ObservableCollection<FoodItem> DinnerLog { get; set; } = new();
        public ObservableCollection<FoodItem> SnacksLog { get; set; } = new();

        


        // Using ICommand for button event handling 

        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand ClearDailyLogCommand { get; }

        // Temporary properties for user input
        
        public string FoodName { get; set; } = "";
        public double Calories { get; set; } = 0;
        public double Protein { get; set; } = 0;
        public double Carbs { get; set; } = 0;
        public double Fats { get; set; } = 0;
        public string SelectedMeal { get; set; } = "Breakfast"; // Default selection
        public DateTime Date { get; set; } = DateTime.Today; // Todays date for daily tracking
        public string ImageUrl { get; set; } = ""; // url to the food items image



        // constructor 
        public DailyLogViewModel()
        {

            // Binding commands for deleting food items 
            AddItemCommand = new RelayCommand(AddFoodItem);
            DeleteItemCommand = new RelayCommand<FoodItem>(DeleteItem);
            ClearDailyLogCommand = new RelayCommand(ClearDailyLog);

            LoadDailyLog(DateTime.Today); // Load the daily log for today from the database 
        }

        // methods 

        // Manaully add food item 
        public void AddFoodItem()
        {
           
            var newFoodItem = new FoodItem
            {
                Name = FoodName,
                Calories = Calories,
                Protein = Protein,
                Carbs = Carbs,
                Fats = Fats,
                MealType = SelectedMeal,
                Date = DateTime.Today, 

      
            };

            switch (SelectedMeal)
            {
                case "Breakfast":
                    BreakfastLog.Add(newFoodItem);
                    break;
                case "Lunch":
                    LunchLog.Add(newFoodItem);
                    break;
                case "Dinner":
                    DinnerLog.Add(newFoodItem);
                    break;
                case "Snacks":
                    SnacksLog.Add(newFoodItem);
                    break;
            }

            UpdateDailyTotals();

        }

        // add food item from search results
        public void AddFoodItemFromSearch(FoodItem item)
        {
            
            switch (item.MealType)
            {
                case "Breakfast":
                    BreakfastLog.Add(item); 
                    break;
                case "Lunch": 
                    LunchLog.Add(item);
                    break;
                case "Dinner":
                    DinnerLog.Add(item);
                    break;
                case "Snacks": 
                    SnacksLog.Add(item); 
                    break;
            }

            UpdateDailyTotals();
        }

        // Update Daily totals 
        private void UpdateDailyTotals()
        {
            // Update Total calories in the daily totals class 
            DailyTotals.TotalCalories = BreakfastLog.Sum(t => t.Calories) + LunchLog.Sum(t => t.Calories)
                                       + DinnerLog.Sum(t => t.Calories) + SnacksLog.Sum(t => t.Calories);
            // calculate total protein 
            DailyTotals.TotalProtein = BreakfastLog.Sum(t => t.Protein) + LunchLog.Sum(t => t.Protein)
                                        + DinnerLog.Sum(t => t.Protein) + SnacksLog.Sum(t => t.Protein);
            // calculate total carbs 
            DailyTotals.TotalCarbs = BreakfastLog.Sum(t => t.Carbs) + LunchLog.Sum(t => t.Carbs)
                                        + DinnerLog.Sum(t => t.Carbs) + SnacksLog.Sum(t => t.Carbs);
            // calculate total fats 
            DailyTotals.TotalFats = BreakfastLog.Sum(t => t.Fats) + LunchLog.Sum(t => t.Fats)
                                    + DinnerLog.Sum(t => t.Fats) + SnacksLog.Sum(t => t.Fats);
            // update the UI 
            OnPropertyChanged(nameof(DailyTotals));
        }


        // delete a food item 
        private void DeleteItem(FoodItem item)
        {
            Console.WriteLine("DeleteItem Command Triggered!"); // for testing delete button 

            if (item == null)
                return;

            // Remove food item from UI ObservableCollection
            switch (item.MealType)
            {
                case "Breakfast":
                    BreakfastLog.Remove(item);
                    break;
                case "Lunch":
                    LunchLog.Remove(item);
                    break;
                case "Dinner":
                    DinnerLog.Remove(item);
                    break;
                case "Snacks":
                    SnacksLog.Remove(item);
                    break;
            }

            //  Remove food item from the Database
            _db.FoodItems.Remove(item);
            _db.SaveChanges();

            
            // notify the ui to update total 
            UpdateDailyTotals();
        }

        // clear the daily food log 
        // will remove all food items from collections 
        private void ClearDailyLog()
        {

           

            // clear all food items from the collections
            BreakfastLog.Clear();
            LunchLog.Clear();
            DinnerLog.Clear();
            SnacksLog.Clear();

            DeleteDailyLog(DateTime.Today); // delete the daily log from the database

            // notify the ui to update total 
            UpdateDailyTotals();
        }

        // Database Methods 
        // Load DailyLog from database (by date)
        public void LoadDailyLog(DateTime date)
        {
            var log = _db.DailyLogs
                              .Include(d => d.FoodItems)
                              .FirstOrDefault(d => d.Date == date);

            if (log != null)
            {
                BreakfastLog = new ObservableCollection<FoodItem>(log.FoodItems.Where(f => f.MealType == "Breakfast"));
                LunchLog = new ObservableCollection<FoodItem>(log.FoodItems.Where(f => f.MealType == "Lunch"));
                DinnerLog = new ObservableCollection<FoodItem>(log.FoodItems.Where(f => f.MealType == "Dinner"));
                SnacksLog = new ObservableCollection<FoodItem>(log.FoodItems.Where(f => f.MealType == "Snacks"));
            }
            else
            {
                // No existing log so we can initialize an empty collection 
                BreakfastLog = new ObservableCollection<FoodItem>();
                LunchLog = new ObservableCollection<FoodItem>();
                DinnerLog = new ObservableCollection<FoodItem>();
                SnacksLog = new ObservableCollection<FoodItem>();
            }

            // Notify the UI to update the collections
            OnPropertyChanged(nameof(BreakfastLog));
            OnPropertyChanged(nameof(LunchLog));
            OnPropertyChanged(nameof(DinnerLog));
            OnPropertyChanged(nameof(SnacksLog));
            UpdateDailyTotals();
        }

       
        // Save DailyLog and all food items to the DB
        public void SaveDailyLog()
        {
          
            var existingLog = _db.DailyLogs
                                      .Include(d => d.FoodItems)
                                      .FirstOrDefault(d => d.Date == Date);

            if (existingLog != null)
            {
                _db.FoodItems.RemoveRange(existingLog.FoodItems);
                _db.DailyLogs.Remove(existingLog);
                _db.SaveChanges();
            }

            var dailyLog = new DailyLog { Date = Date };
            var allItems = BreakfastLog.Concat(LunchLog).Concat(DinnerLog).Concat(SnacksLog).ToList();

            foreach (var item in allItems)
            {
                item.DailyLogs = dailyLog;
                dailyLog.FoodItems.Add(item);
            }

            _db.DailyLogs.Add(dailyLog);
            _db.SaveChanges();
        }

       
        // Delete DailyLog from the database
        public void DeleteDailyLog(DateTime date)
        {
            var log = _db.DailyLogs.Include(d => d.FoodItems).FirstOrDefault(d => d.Date == date);

            if (log != null)
            {
                _db.FoodItems.RemoveRange(log.FoodItems); // Remove food items first (they are related to the log)
                _db.DailyLogs.Remove(log); // Then the log itself is removed
                _db.SaveChanges(); // Save changes to the database

                // Clear current UI if the deleted date is selected
                if (date.Date == Date.Date)
                {
                    ClearDailyLog();
                }
            }
        }




    }
}
