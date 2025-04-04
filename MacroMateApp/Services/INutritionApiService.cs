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
        Task<List<FoodItem>> SearchFood(string query);
    }
}
