using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Models;

namespace MacroMateApp.Services
{
    // Interface for NutritionApiService
    public interface INutritionApiService
    {
        // Method to search for food items and return a list of FoodItem objects
        Task<List<FoodItem>> SearchFood(string query);
    }
}
