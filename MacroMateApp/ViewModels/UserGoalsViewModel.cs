using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MacroMateApp.Models;
using MacroMateApp.Data;

namespace MacroMateApp.ViewModels
{
    public class UserGoalsViewModel : INotifyPropertyChanged
    {
        private UserGoals _goals;
        public UserGoals Goals
        {
            get => _goals;
            set
            {
                _goals = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveGoalsCommand { get; }
        public ICommand ClearGoalsCommand { get; }

        public UserGoalsViewModel()
        {
            SaveGoalsCommand = new RelayCommand(SaveGoals);
            ClearGoalsCommand = new RelayCommand(ClearUserGoals);
            LoadGoals(); // Load goals from DB on view model init
        }

        private void SaveGoals()
        {
            using (var db = new ApplicationDbContext())
            {
                var existingGoals = db.UserGoals.FirstOrDefault();

                if (existingGoals != null)
                {
                    existingGoals.CaloriesGoal = Goals.CaloriesGoal;
                    existingGoals.ProteinGoal = Goals.ProteinGoal;
                    existingGoals.CarbGoal = Goals.CarbGoal;
                    existingGoals.FatGoal = Goals.FatGoal;
                }
                else
                {
                    db.UserGoals.Add(Goals);
                }

                db.SaveChanges();
            }

            LoadGoals(); // Refresh the UI
        }

        private void LoadGoals()
        {
            using (var db = new ApplicationDbContext())
            {
                Goals = db.UserGoals.FirstOrDefault() ?? new UserGoals();
            }
        }

        /// <summary>
        /// Deletes the current UserGoals from the database and resets the local Goals instance.
        /// </summary>
        public void ClearUserGoals()
        {
            using (var db = new ApplicationDbContext())
            {
                var existingGoals = db.UserGoals.FirstOrDefault();
                if (existingGoals != null)
                {
                    db.UserGoals.Remove(existingGoals);
                    db.SaveChanges();
                }
            }

            Goals = new UserGoals(); // Reset the property so UI updates
        }

        // Notify UI of property changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
