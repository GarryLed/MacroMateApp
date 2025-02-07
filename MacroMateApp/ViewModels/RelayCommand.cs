using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MacroMateApp.ViewModels
{
    // class will handle button actions  in wpf 
    // this will replace having to use event handlers for buttons in wpf 
    // goal: bind the buttons command to relay command (separation of concerns) 
    public class RelayCommand : ICommand // implement ICommand interface to allow buttons to bind to commands in the viewModel 
    {

        // properties 
        private readonly Action _execute; // holds the method to execute when the command is triggered 
        private readonly Func<bool> _canExecute; // returns a value of the of the _canExecute function (bool) 

        // constructor 
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // methods 
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(); // _canExecute == null determines if the command can run (if no condition 
        // is provided, the command is always enabled. _canExecute() => if condition exists, it eill call the function and return its result 
        
        // returns the assigned action when the button is clicked 
        public void Execute(object parameter)
        {
            _execute();
        }

        // can execute changed event: 
        // notifies the UI dynimically when the result of CanExecute() changes 
        // WPF will listen to this event to enable or disable the buttons dynimically 
        public event EventHandler CanExecuteChanged;
    

        

    }
}
