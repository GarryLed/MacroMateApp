using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Models;

namespace MacroMate.Tests.Unit.Models
{
    class DailyTotalsTest
    {
        [Test]
        public void TestTotalDailyCalories() // Testing for daily calories set to specified value
        {

            // arrange 
            var totals = new DailyTotals();

            // act
            totals.TotalCalories = 2500;

            // assert
            Assert.That(totals.TotalCalories, Is.EqualTo(2500));

        }

        [Test]
        public void TestTotalDailyProtein() // Testing for daily protein set to specified value
        {
            // arrange 
            var totals = new DailyTotals();
            // act
            totals.TotalProtein = 150;
            // assert
            Assert.That(totals.TotalProtein, Is.EqualTo(150));
        }

        [Test]
        public void TestTotalDailyCarbs() // Testing for daily carbs set to specified value
        {
            // arrange 
            var totals = new DailyTotals();
            // act
            totals.TotalCarbs = 200;
            // assert
            Assert.That(totals.TotalCarbs, Is.EqualTo(200));
        }

        [Test]
        public void TestTotalDailyFats() // Testing for daily fats set to specified value
        {
            // arrange 
            var totals = new DailyTotals();
            // act
            totals.TotalFats = 70;
            // assert
            Assert.That(totals.TotalFats, Is.EqualTo(70));
        }

        [Test]
        public void TestTotalDailyCaloriesPropertyChanged() // Testing for property changed event
        {
            // arrange 
            var totals = new DailyTotals();
            var propertyChanged = false;
            totals.PropertyChanged += (sender, e) => propertyChanged = true;

            // act
            totals.TotalCalories = 3000;

            // assert
            Assert.That(propertyChanged, Is.True);
        }

        [Test]
        public void TestTotalDailyProteinPropertyChanged() // Testing for property changed event on Protein 
        {
            // arrange 
            var totals = new DailyTotals();
            var propertyChanged = false;
            totals.PropertyChanged += (sender, e) => propertyChanged = true;
            // act
            totals.TotalProtein = 200;
            // assert
            Assert.That(propertyChanged, Is.True);
        }

        [Test]
        public void TestTotalDailyCarbsPropertyChanged() // Testing for property chhnaged event on carbs 
        {
            // arrange 
            var totals = new DailyTotals();
            var propertyChanged = false;
            totals.PropertyChanged += (sender, e) => propertyChanged = true;
            // act
            totals.TotalCarbs = 300;
            // assert
            Assert.That(propertyChanged, Is.True);
        }

        [Test]
        public void TestTotalDailyFatsPropertyChanged() // Testing for property changed event on fats 
        {
            // arrange 
            var totals = new DailyTotals();
            var propertyChanged = false;
            totals.PropertyChanged += (sender, e) => propertyChanged = true;
            // act
            totals.TotalFats = 65;
            // assert
            Assert.That(propertyChanged, Is.True);
        }
    }
}
