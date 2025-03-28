﻿
using System;
using System.Collections.ObjectModel;         
using System.ComponentModel;                  
using System.Runtime.CompilerServices;        
using System.Threading.Tasks;                 
using System.Windows.Input;                   
using MacroMateApp.Models;                    
using MacroMateApp.Services;                  
using MacroMateApp.Data;                      

namespace MacroMateApp.ViewModels
{
    // this is the ViewModel class for food search
    public class FoodSearchViewModel : INotifyPropertyChanged
    {
        // access the nutrition API service
        private readonly NutritionApiService _nutritionService;

        // stores the user’s search query 
        private string _searchQuery;

        // the food item that is selected from the search results
        private FoodItem _selectedFoodItem;

        // selected meal type that defaults to Breakfast
        private string _selectedMeal = "Breakfast";

        // reference to the shared DailyLogViewModel for adding food items to the daily log
        private readonly DailyLogViewModel _dailyLogViewModel;

        // event for notifying UI anytime a property changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // constructor that takes a DailyLogViewModel as a parameter so it can be used to add food items to the daily log
        public FoodSearchViewModel(DailyLogViewModel dailyLogViewModel)
        {
            _dailyLogViewModel = dailyLogViewModel; // Store reference for use in AddSelectedFoodToLog
            _nutritionService = new NutritionApiService(); // create a new instance of the API service
            FoodResults = new ObservableCollection<FoodItem>(); // create a new instance of the observable collection that will store the search results 

            // command for triggering a food search
            SearchCommand = new RelayCommand(async () => await SearchFood());

            // command for adding a selected food item to the daily log (initially disabled)
            AddToLogCommand = new RelayCommand(AddSelectedFoodToLog, () => SelectedFoodItem != null);


            // initialize SelectedFoodItem to avoid null reference exceptions (not having this line caused a bug)
            SelectedFoodItem = new FoodItem();
        }

        // binding property for the user's search query
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(); // Notify UI of change
            }
        }

        // observable collection of search results (used for displaying food items)
        public ObservableCollection<FoodItem> FoodResults { get; }

        // selected food item from the search results
        public FoodItem SelectedFoodItem
        {
            get => _selectedFoodItem;
            set
            {
                _selectedFoodItem = value;
                OnPropertyChanged(); // update the ui with the selected food item

                // Command that allows the AddToLogCommand to re-evaluate if it can execute (based on selection)
                ((RelayCommand)AddToLogCommand).RaiseCanExecuteChanged();

                System.Diagnostics.Debug.WriteLine($"Selected: {_selectedFoodItem?.Name} | {_selectedFoodItem?.Calories} kcal");
            }
        }

        // the selected meal category by the user (Breakfast, Lunch, Dinner, Snacks)
        public string SelectedMeal
        {
            get => _selectedMeal;
            set
            {
                _selectedMeal = value;
                OnPropertyChanged(); 
            }
        }

        // command that triggers the search query
        public ICommand SearchCommand { get; }

        // command that adds the selected food to the daily log
        public ICommand AddToLogCommand { get; private set; }

        // async method to perform a food search using the nutrition API
        private async Task SearchFood()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
                return; 

            var results = await _nutritionService.SearchFood(SearchQuery); // call the api service and await the results
            FoodResults.Clear(); // clear out any existing results

            // add new results to the observable collection
            foreach (var item in results)
            {
                FoodResults.Add(item);
            }
        }

        // add the selected food item to the appropriate meal log
        
        private void AddSelectedFoodToLog()
        {
            if (SelectedFoodItem == null)
                return;

            // create a new FoodItem object for logging the food 
            var newFoodItem = new FoodItem
            {
                // TEMP RESULT BUT THE CODE WORKS 
                Name = FoodResults[0].Name,
                Calories = FoodResults[0].Calories,
                Protein = FoodResults[0].Protein,
                Carbs = FoodResults[0].Carbs,
                Fats = FoodResults[0].Fats,
                MealType = SelectedMeal,
                Date = DateTime.Today
            };

            // add the new item to the shared daily log
            _dailyLogViewModel.AddFromSearch(newFoodItem);
        }
        

        // add the selected food item to the appropriate meal log

        /*
        private void AddSelectedFoodToLog(FoodItem foodresults)
        {
            if (foodresults == null)
                return;

            // create a new FoodItem object for logging the food 
            var newFoodItem = new FoodItem
            {
                Name = foodresults.Name,
                Calories = foodresults.Calories,
                Protein = foodresults.Protein,
                Carbs = foodresults.Carbs,
                Fats = foodresults.Fats,
                MealType = SelectedMeal, // broken and need to be fixed 
                Date = DateTime.Today
            };

            // add the new item to the shared daily log
            _dailyLogViewModel.AddFromSearch(newFoodItem);
        }
        */
        //====================
        /*
        private void AddSelectedFoodToLog()
        {
            if (SelectedFoodItem == null)
                return;

            // Copy properties to the shared DailyLogViewModel's inputs
            _dailyLogViewModel.FoodName = SelectedFoodItem.Name;
            _dailyLogViewModel.Calories = SelectedFoodItem.Calories;
            _dailyLogViewModel.Protein = SelectedFoodItem.Protein;
            _dailyLogViewModel.Carbs = SelectedFoodItem.Carbs;
            _dailyLogViewModel.Fats = SelectedFoodItem.Fats;
            _dailyLogViewModel.SelectedMeal = SelectedMeal;

            // Call the shared AddItemCommand
            _dailyLogViewModel.AddItemCommand.Execute(null);
        }

        */


        //=====================


        // notify the UI of property changes
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
