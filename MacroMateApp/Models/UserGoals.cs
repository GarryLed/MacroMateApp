using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MacroMateApp.Models
{
    public class UserGoals : INotifyPropertyChanged
    {
        [Key] // Primary Key for database 
        public int Id { get; set; }

        private double _caloriesGoal;
        public double CaloriesGoal
        {
            get => _caloriesGoal;
            set
            {
                if (_caloriesGoal != value)
                {
                    _caloriesGoal = value;
                    OnPropertyChanged(nameof(CaloriesGoal));
                }
            }
        }

        private double _proteinGoal;
        public double ProteinGoal
        {
            get => _proteinGoal;
            set
            {
                if (_proteinGoal != value)
                {
                    _proteinGoal = value;
                    OnPropertyChanged(nameof(ProteinGoal));
                }
            }
        }

        private double _carbGoal;
        public double CarbGoal
        {
            get => _carbGoal;
            set
            {
                if (_carbGoal != value)
                {
                    _carbGoal = value;
                    OnPropertyChanged(nameof(CarbGoal));
                }
            }
        }

        private double _fatGoal;
        public double FatGoal
        {
            get => _fatGoal;
            set
            {
                if (_fatGoal != value)
                {
                    _fatGoal = value;
                    OnPropertyChanged(nameof(FatGoal));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

