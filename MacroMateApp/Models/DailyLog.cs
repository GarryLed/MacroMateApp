using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema; // for sqlite database

namespace MacroMateApp.Models
{
    // DailyLog class to represent a daily log of food items
    [Table("DailyLogs")]
    public class DailyLog
    {
        [Key]
        public int DailyLogId { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        // Navigation property (one to many relationship between daily log and food items) 
        public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
    }
}
