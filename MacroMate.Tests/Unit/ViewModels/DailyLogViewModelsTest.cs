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
    class DailyLogViewModelsTest
    {
        [Test]
        public void TestManualAddFoodItem()
        {
            // arrange 
            var ViewModel = new DailyLogViewModel();


            // act 
            ViewModel.FoodName = "Apple";
            ViewModel.Calories = 95;
            ViewModel.Protein = 0.5;
            ViewModel.Carbs = 25;
            ViewModel.Fats = 0.3;
            ViewModel.SelectedMeal = "Breakfast";
            ViewModel.Date = DateTime.Today;

           ViewModel.AddFoodItem();

            // assert 
            Assert.That(ViewModel.BreakfastLog.Count, Is.EqualTo(3)); // 2 objects hardcoaded in the constructor + 1 new object
            Assert.That(ViewModel.DailyTotals.TotalCalories, Is.EqualTo(1346));

        }

        


    }
}
