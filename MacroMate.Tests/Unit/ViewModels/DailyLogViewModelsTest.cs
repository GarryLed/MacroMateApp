using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Models;
using MacroMateApp.ViewModels;

namespace MacroMate.Tests.Unit.ViewModels
{
    /// <summary>
    /// Test class for DailyLogViewModels
    /// </summary>
    [TestFixture]
    class DailyLogViewModelsTest
    {
        [Test]
        public void TestAddFoodItem_AddsItemToMealLog_AndUpdatesTotals() // Test for adding food item
        {
            // Arrange
            var item = new DailyLogViewModel
            {
                FoodName = "Test Apple",
                Calories = 95,
                Protein = 0.5,
                Carbs = 25,
                Fats = 0.3,
                SelectedMeal = "Lunch"
            };

            // Act
            item.AddItemCommand.Execute(null);

            // Assert
            
            Assert.That(item.DailyTotals.TotalCalories, Is.GreaterThanOrEqualTo(95));
        }

        [Test]
        public void TestAddFoodItemFromSearch_AddsItemToMealLog_AndUpdatesTotals() // Test for adding food item from search
        {
            // Arrange
            var vm = new DailyLogViewModel();
           
            var food = new FoodItem
            {
                Name = "Test Apple",
                Calories = 95,
                Protein = 0.5,
                Carbs = 25,
                Fats = 0.3,
                MealType = "Lunch"
            };
            // Act
            vm.AddFoodItemFromSearch(food);

            // Assert
            Assert.That(vm.DailyTotals.TotalCalories, Is.GreaterThanOrEqualTo(95));
        }


    }
}
