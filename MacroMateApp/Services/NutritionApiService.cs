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
    public class NutritionApiService 
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

            dynamic data = JsonConvert.DeserializeObject(json);

            var foodList = new List<FoodItem>();

            foreach (var item in data.parsed)
            {
                //string foodId = item.food.foodId;
                string label = item.food.label;
                double calories = item.food.nutrients.ENERC_KCAL ?? 0;
                double protein = item.food.nutrients.PROCNT ?? 0;
                double carbs = item.food.nutrients.CHOCDF ?? 0;
                double fats = item.food.nutrients.FAT ?? 0;
                string image = item.food.image ?? "";

                string servingSize = "100g";
                if (item.food.measures != null)
                {
                    servingSize = item.food.measures[0].label;
                }

                foodList.Add(new FoodItem
                {
                    //  FoodId = foodId,
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