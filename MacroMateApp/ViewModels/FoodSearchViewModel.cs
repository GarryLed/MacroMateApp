
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
        private readonly NutritionApiService _nutritionService;
        private string _searchQuery = string.Empty; 
        private FoodItem _selectedFoodItem = new FoodItem(); 
        private string _selectedMeal = "Breakfast";
        private readonly DailyLogViewModel _dailyLogViewModel;
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly INutritionApiService _nutritionApiService;

        public FoodSearchViewModel(INutritionApiService nutritionService, DailyLogViewModel dailyLogViewModel)
        {
            _nutritionApiService = nutritionService ?? throw new ArgumentNullException(nameof(nutritionService)); 
            _dailyLogViewModel = dailyLogViewModel ?? throw new ArgumentNullException(nameof(dailyLogViewModel)); 
            FoodResults = new ObservableCollection<FoodItem>();

            SearchCommand = new RelayCommand(async () => await SearchFood());
            AddToLogCommand = new RelayCommand(AddSelectedFoodToLog, () => SelectedFoodItem != null);
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FoodItem> FoodResults { get; }

        public FoodItem SelectedFoodItem
        {
            get => _selectedFoodItem;
            set
            {
                _selectedFoodItem = value;
                OnPropertyChanged();
                ((RelayCommand)AddToLogCommand).RaiseCanExecuteChanged();
            }
        }

        public string SelectedMeal
        {
            get => _selectedMeal;
            set
            {
                _selectedMeal = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }

        public ICommand AddToLogCommand { get; private set; }

        private async Task SearchFood()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
                return;

            var results = await _nutritionApiService.SearchFood(SearchQuery);
            FoodResults.Clear();

            foreach (var item in results)
            {
                FoodResults.Add(item);
            }
        }

        private void AddSelectedFoodToLog()
        {
            if (SelectedFoodItem == null)
                return;

            var newFoodItem = new FoodItem
            {
                Name = FoodResults[0].Name,
                Calories = FoodResults[0].Calories,
                Protein = FoodResults[0].Protein,
                Carbs = FoodResults[0].Carbs,
                Fats = FoodResults[0].Fats,
                MealType = SelectedMeal,
                Date = DateTime.Today,
                ImageUrl = FoodResults[0].ImageUrl
            };

            _dailyLogViewModel.AddFoodItemFromSearch(newFoodItem);
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
