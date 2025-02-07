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
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
       
    }
}