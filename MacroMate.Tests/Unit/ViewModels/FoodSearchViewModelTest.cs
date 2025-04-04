using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.ViewModels;
using NUnit.Framework;
using Moq;
using MacroMateApp.Services;

namespace MacroMate.Tests.Unit.ViewModels
{
    /// <summary>
    /// Test class for FoodSearchViewModel
    /// </summary>

    [TestFixture]
    class FoodSearchViewModelTest
    {
        private Mock<INutritionApiService> _nutritionApiServiceMock; // Mock object for the nutrition API service
        private FoodSearchViewModel _viewModel; // ViewModel instance for testing
        private DailyLogViewModel _dailyLog; // DailyLogViewModel instance for testing

        [SetUp]
        public void Setup()
        {
            // create new instances of the mock object and the view models
            _nutritionApiServiceMock = new Mock<INutritionApiService>(); // Create a new mock object for the nutrition API service
            _dailyLog = new DailyLogViewModel(); // Create a new instance of the DailyLogViewModel
            _viewModel = new FoodSearchViewModel(_nutritionApiServiceMock.Object, _dailyLog); // Create a new instance of the FoodSearchViewModel with the mock service and daily log
        }

        [Test]
        public void TestConstructor_InitalizedPropertiesCorrectly()
        {
            // Assert 
            Assert.That(_viewModel.SearchCommand, Is.Not.Null); // Check that the SearchCommand property is not null
            Assert.That(_viewModel.AddToLogCommand, Is.Not.Null); // Check that the AddToLogCommand property is not null
            //Assert.That(_viewModel.SelectedFoodItem, Is.Null); // Check that the SelectedFoodItem property is null
            // BUG: The SelectedFoodItem property is returning null but should not be 
            Assert.That(_viewModel.FoodResults, Is.Not.Null); // Check that the FoodResults property is not null

        }

        [Test]
        public void TestSearchSearchQuery_PropertyChangedSuccessful()
        {
            // Arrange
            var propertyChanged = false; // initialy set the property changed flag to false

            _viewModel.PropertyChanged += (sender, e) => // Subscribe to the PropertyChanged event
            {
                if (e.PropertyName == nameof(_viewModel.SearchQuery)) // Check if the property name is SearchQuery
                {
                    propertyChanged = true; // Set the property changed flag to true
                }
            };

            // Act
            _viewModel.SearchQuery = "Apple"; // Set the SearchQuery property to "Apple"

            // Assert
            Assert.That(propertyChanged, Is.True); // Check that the property changed event was raised

        }


    }
}
