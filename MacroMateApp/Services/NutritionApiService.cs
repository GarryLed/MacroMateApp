using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Models;
using Newtonsoft.Json.Linq;

namespace MacroMateApp.Services
{
    /// <summary>
    /// This class handles all API requests and JSON parsing 
    /// </summary>
    public class NutritionApiService
    {
        /*
        private readonly string apiKey = "BVQjXXzU6oySRzHwL02cSDYX9Kf5wFpD0P8xW0aA"; // API Key (will hide this for safety) 
        private readonly string apiUrl = "https://api.nal.usda.gov/fdc/v1/foods/search";
        private readonly HttpClient _httpClient;

        // constructor 
        public NutritionApiService()
        {
            _httpClient = new HttpClient();
        }

        /*
        public async Task<List<FoodItem>> FetchFoodInfoAsync(string foodName)
        {

            // api url 
            string requestUrl = $"{apiUrl}?query={foodName}&{apiKey}"; 

            // try catch 
            try
            {
                // makding a GET request 
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"API request failed: {response.StatusCode}");
                }

                // reading the api response as JSON
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // parse the json and return the data 
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching data: {ex.Message}");
            }

        }

        // parse json response from api and extract the food nutrition data 
        private List<FoodItem>ParseFoodInfo(string jsonResponse)
        {
            // create an empty list to store parsed food 
            List<FoodItem> foodlist = new List<FoodItem>();

            // parse the json response 
            JObject json = JObject.Parse(jsonResponse);

            // this extracts the foods array form the json response 
            var foods = json["foods"];

            foreach (var food in foods)
            {
                // create a new FoodItem object and add the foods 
                FoodItem foodItem = new FoodItem
                {
                    Name = food["description"]?.ToString(), // This extracts the food name 
                    // add rest of food info here 
                };


            }
        }

        // Extract a nutrient value from a food item in json 
        private int GetNutritionValue(JToken food, string nutrientName)
        {
            var nutrients = food["foodNutrients"]; // gets the foodNutrients array 

            if (nutrients != null)
            {
                // loop through foodNutrients array 
                foreach (var nutrient in nutrients)
                {
                    // check if nutrients match 
                    if (nutrient["nutrientName"].ToString().Contains(nutrientName))
                    {
                        // return an int here 
                    }
                }
            }
            
        }
        */
    }
}
