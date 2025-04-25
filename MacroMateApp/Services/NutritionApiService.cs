using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MacroMateApp.Services
{
    public class NutritionApiService : INutritionApiService // implementing the INutritionApiService interface for testing 
    {
        private readonly string appId = "30552731";
        private readonly string appKey = "2198f3549a810314e56105169b3c8c9e";
        private readonly HttpClient _httpClient;

        public NutritionApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<FoodItem>> SearchFood(string query)
        {
            string url = $"https://api.edamam.com/api/food-database/v2/parser?app_id={appId}&app_key={appKey}&ingr={Uri.EscapeDataString(query)}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // display error to console 
                Console.WriteLine($"API error: {response.StatusCode}");
                return new List<FoodItem>();
            }
            string json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API data: {json}");

            var data = JsonConvert.DeserializeObject<dynamic>(json); // Deserilises the json data string into a .NET object (dynamic) 
            // alternatively, I could have used strongly typed class to deserialize the JSON data into a specific object structure
            // like a FoodResponse class with properties matching the JSON structure and FoodParsed class with properties matching the parsed food items
            if (data == null)
            {
                Console.WriteLine("Deserialization returned null.");
                return new List<FoodItem>();
            }

            var foodList = new List<FoodItem>();

            foreach (var item in data.parsed)
            {
                string label = item.food.label ?? string.Empty;
                double calories = item.food.nutrients.ENERC_KCAL ?? 0;
                double protein = item.food.nutrients.PROCNT ?? 0;
                double carbs = item.food.nutrients.CHOCDF ?? 0;
                double fats = item.food.nutrients.FAT ?? 0;
                string image = item.food.image ?? "";

                string servingSize = "100g"; // default serving size
                if (item.food.measures != null && item.food.measures.Count > 0)
                {
                    servingSize = item.food.measures[0].label ?? servingSize;
                }

                foodList.Add(new FoodItem // create a new food item object and add it to the list
                {
                    Name = label,
                    Calories = calories,
                    Protein = protein,
                    Carbs = carbs,
                    Fats = fats,
                    ServingSize = servingSize,
                    ImageUrl = image
                });
            }

            return foodList;
        }
    }
}