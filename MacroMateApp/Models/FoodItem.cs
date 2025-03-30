using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs; // for sqlite database 

namespace MacroMateApp.Models
{
    public class FoodItem
    {
        // properties 
        [Key] 
        public int FoodId { get; set; } // primary key 

        [Required] 
        public string Name { get; set; } // Food Item name is required for 

        [Required]
        public double Calories { get; set; }

        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
        public string ServingSize { get; set; } = "1 serving"; // set default serving size to 1 serving 

        public string MealType { get; set; } = "Breakfast"; // set defaule meal type to Breakfast 

        public DateTime Date { get; set; } = DateTime.Today; // Todays date for daily tracking 

        public string ImageUrl { get; set; } = "";// url to the food items image 



    }
}