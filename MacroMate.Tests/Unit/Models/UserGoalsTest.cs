using MacroMateApp.Models;

namespace MacroMate.Tests.Unit.Models
{
    /// <summary>
    /// Test class for UserGoals
    /// </summary>
    class UserGoalsTest
    {
        [Test]
        public void TestUserGoals() // Test for UserGoals set to specified values
        {
            // Arrange
            var userGoals = new UserGoals
            {
                CaloriesGoal = 2000,
                ProteinGoal = 150,
                CarbGoal = 250,
                FatGoal = 70
            };

            // Act
            var caloriesGoal = userGoals.CaloriesGoal;
            var proteinGoal = userGoals.ProteinGoal;
            var carbGoal = userGoals.CarbGoal;
            var fatGoal = userGoals.FatGoal;

            // Asser
            Assert.That(caloriesGoal, Is.EqualTo(2000));
            Assert.That(proteinGoal, Is.EqualTo(150));
            Assert.That(carbGoal, Is.EqualTo(250));
            Assert.That(fatGoal, Is.EqualTo(70));
               
        }

        [Test]
        public void TestUserGoalsPropertyChanged() // Test for property changed event
        {
            // Arrange
            var userGoals = new UserGoals();
            var propertyChanged = false;
            userGoals.PropertyChanged += (sender, e) => propertyChanged = true;
            // Act
            userGoals.CaloriesGoal = 3000;
            // Assert
            Assert.That(propertyChanged, Is.True);
        }

        [Test]
        public void TestUserGoalsSetToDefaultValues() // Test for UserGoals set to default values
        {
            // Arrange
            var userGoals = new UserGoals();

            // Act
            userGoals.CaloriesGoal = 0;
            userGoals.ProteinGoal = 0;
            userGoals.CarbGoal = 0;
            userGoals.FatGoal = 0;

            // Assert
            Assert.That(userGoals.CaloriesGoal, Is.EqualTo(0));
            Assert.That(userGoals.ProteinGoal, Is.EqualTo(0));
            Assert.That(userGoals.CarbGoal, Is.EqualTo(0));
            Assert.That(userGoals.FatGoal, Is.EqualTo(0));
            
        }
       
    }
}
