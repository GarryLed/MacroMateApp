using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMateApp.Models;

namespace MacroMateApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserGoals> UserGoals { get; set; } // will map user goals to table in the database 
        public DbSet<FoodItem> FoodLog { get; set; } // will store the logged food in the database 

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=macroMate.db"); // our local Sqlite database file 
        }
    }
}
