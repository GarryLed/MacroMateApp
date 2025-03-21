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
        private double _totalCalories;
        private double _totalProtein;
        private double _totalCarbs;
        private double _totalFats; 


        public double TotalCalories 
        {
            get => _totalCalories;
            set
            {
                _totalCalories = value;
                OnPropertyChanged(nameof(TotalCalories));
            }
        }

        public double TotalProtein
        {
            get => _totalProtein;
            set
            {
                _totalProtein = value;
                OnPropertyChanged(nameof(TotalProtein));
            }

        }

        public double TotalCarbs
        {
            get => _totalCarbs;
            set
            {
                _totalCarbs = value;
                OnPropertyChanged(nameof(TotalCarbs));
            }
        }

        public double TotalFats
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
