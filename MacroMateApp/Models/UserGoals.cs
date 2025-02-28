using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MacroMateApp.Models
{
    public class UserGoals
    {
        [Key] // Primary Key for database 
        public int Id { get; set; }
        // properties 
        public double CaloriesGoal { get; set; }
        public double ProteinGoal { get; set; }
        public double CarbGoal { get; set; }
        public double FatGoal { get; set; }
    }
}
