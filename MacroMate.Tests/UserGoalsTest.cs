using MacroMateApp.Models;

namespace MacroMate.Tests
{
    /// <summary>
    /// Test class for UserGoals
    /// </summary>
    class UserGoalsTest
    {
        [Test]
        public void TestUserGoals()
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

            // Assert
            Assert.AreEqual(2000, caloriesGoal);
            Assert.AreEqual(150, proteinGoal);
            Assert.AreEqual(250, carbGoal);
            Assert.AreEqual(70, fatGoal);
        }
    }
}
