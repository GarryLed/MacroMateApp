using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Models;
using MacroMateApp.Data;
using System.Windows.Input;


namespace MacroMateApp.ViewModels
{
    public class UserGoalsViewModel
    {
        public UserGoals Goals { get; set; } = new UserGoals();

        public ICommand SaveGoalsCommand { get; } // biding for saving goals 

        public UserGoalsViewModel()
        {
            SaveGoalsCommand = new RelayCommand(SaveGoals);
            //LoadGoals; 
        }

        // Save goals method 
        private void SaveGoals()
        {
            using (var db = new ApplicationDbContext())
            {
                var currentGoals = db.UserGoals.FirstOrDefault();

                if (currentGoals != null)
                {
                    currentGoals.CaloriesGoal = Goals.CaloriesGoal;
                    currentGoals.ProteinGoal = Goals.ProteinGoal;
                    currentGoals.CarbGoal = Goals.CarbGoal;
                    currentGoals.FatGoal = Goals.FatGoal;
                }
                else
                {
                    db.UserGoals.Add(Goals);
                }

                db.SaveChanges(); // save chages to database 
            }
        }

        // lodading goals 
        private void LoadGoals()
        {
            using (var db = new ApplicationDbContext())
            {
                Goals = db.UserGoals.FirstOrDefault() ?? new UserGoals();
            }
        }
    }
}
