using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.ViewModels;

namespace MacroMate.Tests.Unit.ViewModels
{
    /// <summary>
    /// Test class for RelayCommand class
    /// </summary>

    [TestFixture]
    class RelayCommandTest
    {
        [Test]
        public void TestRelayCommand_Execute_CallsAction() // tests when the command is executed, the action is called
        {
            // Arrange
            bool wasExecuted = false;
            var command = new RelayCommand(() => wasExecuted = true);

            // Act
            command.Execute(null);

            // Assert
            Assert.That(wasExecuted, Is.EqualTo(true));
        }


        [Test]
        public void RelayCommandT_Execute_CallsActionWithParameter() // tests when the command is executed, the action is called with a parameter
        {
            // Arrange
            int executedValue = 0;
            var command = new RelayCommand<int>((x) => executedValue = x);

            // Act
            command.Execute(42);

            // Assert
            Assert.That(executedValue, Is.EqualTo(42));
        }


    }
}
