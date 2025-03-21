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
using MacroMateApp.Services;
using System.Runtime.CompilerServices;

namespace MacroMateApp.ViewModels
{
    public class FoodSearchViewModel : INotifyPropertyChanged
    {
        private readonly NutritionApiService _nutritionService;
        private string _searchQuery;

        public event PropertyChangedEventHandler PropertyChanged;

        public FoodSearchViewModel()
        {
            _nutritionService = new NutritionApiService();
            FoodResults = new ObservableCollection<FoodItem>();
            SearchCommand = new RelayCommand(async () => await SearchFood());
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        public ObservableCollection<FoodItem> FoodResults { get; }

        public ICommand SearchCommand { get; }

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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}