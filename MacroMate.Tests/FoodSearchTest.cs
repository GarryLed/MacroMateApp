using MacroMateApp.Models;

namespace MacroMate.Tests
{
    class FoodSearchTest
    {
        [Test]
        public void TestFoodSearch()
        {
            // Arrange
            var foodSearch = new FoodSearch
            {
                FoodName = "Apple",
                Calories = 95,
                Protein = 0.5,
                Carbs = 25,
                Fats = 0.3
            };
            // Act
            var foodName = foodSearch.FoodName;
            var calories = foodSearch.Calories;
            var protein = foodSearch.Protein;
            var carbs = foodSearch.Carbs;
            var fats = foodSearch.Fats;
            // Assert
            Assert.Equals("Apple", foodName);
            Assert.Equals(95, calories);
            Assert.Equals(0.5, protein);
            Assert.Equals(25, carbs);
            Assert.Equals(0.3, fats);
        }
    }
}
