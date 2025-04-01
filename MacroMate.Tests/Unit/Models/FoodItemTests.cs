using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Models;

namespace MacroMate.Tests.Unit.Models
{
    class FoodItemTests
    {
        [Test]
        public void TestConstructor_SetDefaultValues() // Test for FoodItem constructor set to default values
        {
            // Arrange
            var foodItem = new FoodItem();

            // Act
            var name = foodItem.Name;
            var calories = foodItem.Calories;
            var protein = foodItem.Protein;
            var carbs = foodItem.Carbs;
            var fats = foodItem.Fats;
            var imageUrl = foodItem.ImageUrl;

            // Assert
            Assert.That(name, Is.EqualTo(""));
            Assert.That(calories, Is.EqualTo(0));
            Assert.That(protein, Is.EqualTo(0));
            Assert.That(carbs, Is.EqualTo(0));
            Assert.That(fats, Is.EqualTo(0));
            Assert.That(imageUrl, Is.EqualTo(""));
        }
    }
}
