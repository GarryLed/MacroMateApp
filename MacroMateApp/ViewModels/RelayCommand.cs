using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MacroMateApp.ViewModels
{
    // class will handle commands in wpf 
    // this will replace having to use event handlers in wpf 
    public class RelayCommand : ICommand // implement ICommand interface to allow buttons to bind to commands in the viewModel 
    {

        
        // properties 
        private readonly Action _execute; // method runs when the command is executed 
        private readonly Func<bool> _canExecute;

        // constructor 
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // methods 
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public void Execute(object parameter) => _execute();
        public event EventHandler CanExecuteChanged;
    

        

    }
}
