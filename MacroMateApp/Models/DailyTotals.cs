using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMateApp.Models
{
    public class DailyTotals : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged; 

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // properties 
        private int _totalCalories;
        private int _totalProtein;
        private int _totalCarbs;
        private int _totalFats; 


        public int TotalCalories 
        {
            get => _totalCalories;
            set
            {
                _totalCalories = value;
                OnPropertyChanged(nameof(TotalCalories));
            }
        }

        public int TotalProtein
        {
            get => _totalProtein;
            set
            {
                _totalProtein = value;
                OnPropertyChanged(nameof(TotalProtein));
            }

        }

        public int TotalCarbs
        {
            get => _totalCarbs;
            set
            {
                _totalCarbs = value;
                OnPropertyChanged(nameof(TotalCarbs));
            }
        }

        public int TotalFats
        {
            get => _totalFats;
            set
            {
                _totalFats = value;
                OnPropertyChanged(nameof(TotalFats));
            }
        }

    }
}
