using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Data;
using MacroMateApp.ViewModels;
using MacroMateApp.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace MacroMate.Tests.Unit.ViewModels
{
    /// <summary>
    /// Test class for UserGoalsViewModel
    /// </summary>

    [TestFixture]
    class UserGoalsViewModelTest
    {


        private Mock<ApplicationDbContext> _dbContextMock; // Mock object for the database context
        private Mock<DbSet<UserGoals>> _dbSetMock; // Mock object for the DbSet of UserGoals
        private List<UserGoals> _userGoalsList; // List to simulate the database table

        [SetUp]
        public void Setup()
        {

        }
    }
}
