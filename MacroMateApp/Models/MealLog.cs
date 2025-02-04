using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMateApp.Models
{
    public class MealLog
    {
        // properties 
        public DateTime Date {  get; set; }
        public List<FoodItem> Foods { get; set; } 
        public DailyTotals Totals { get; set; }
    }
}
