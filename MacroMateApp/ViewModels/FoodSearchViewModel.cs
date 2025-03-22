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
    public class FoodSearchViewModel : INotifyPropertyChanged
    {
        private readonly NutritionApiService _nutritionService;
        private string _searchQuery;
        private FoodItem _selectedFoodItem;
        private string _selectedMeal = "Breakfast";

        public event PropertyChangedEventHandler? PropertyChanged;

        public FoodSearchViewModel()
        {
            _nutritionService = new NutritionApiService();
            FoodResults = new ObservableCollection<FoodItem>();

            SearchCommand = new RelayCommand(async () => await SearchFood());
            AddToLogCommand = new RelayCommand(AddSelectedFoodToLog, () => SelectedFoodItem != null); // initialize command first

            SelectedFoodItem = new FoodItem(); // set SelectedFoodItem after initializing commands
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
                // Notify that AddToLogCommand can re-evaluate CanExecute
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

            var results = await _nutritionService.SearchFood(SearchQuery);
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
                Name = SelectedFoodItem.Name,
                Calories = SelectedFoodItem.Calories,
                Protein = SelectedFoodItem.Protein,
                Carbs = SelectedFoodItem.Carbs,
                Fats = SelectedFoodItem.Fats,
                MealType = SelectedMeal,
                Date = DateTime.Today
            };

            App.SharedDailyLogViewModel?.AddFromSearch(newFoodItem);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
