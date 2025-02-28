﻿using System;
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
        public int Id { get; set; } // primary key 

        [Required] 
        public string Name { get; set; } // Food Item name is required for 

        [Required]
        public int Calories { get; set; }

        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }

        public string MealType { get; set; } = "Breakfast"; // set defaule meal type to Breakfast 

        public DateTime Date { get; set; } = DateTime.Today; // Todays date for daily tracking 


       
    }
}