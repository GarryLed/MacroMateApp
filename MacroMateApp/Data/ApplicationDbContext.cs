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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Path to your local 'Data' folder in the project root
            var dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "MacroMate.db");

            // Ensure the folder exists at runtime
            var dbDirectory = System.IO.Path.GetDirectoryName(dbPath);
            if (!System.IO.Directory.Exists(dbDirectory))
            {
                System.IO.Directory.CreateDirectory(dbDirectory);
            }

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }


    }
}
