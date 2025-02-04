using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MacroMateApp.Models
{
    public class FoodItem
    {
        // properties 
        public string Name { get; set; } // Food Item name 
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
        public string Category { get; set; } // meal categories 
    }
}
