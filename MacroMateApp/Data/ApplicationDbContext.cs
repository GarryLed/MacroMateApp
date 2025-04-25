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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "MacroMate.db");

            var dbDirectory = System.IO.Path.GetDirectoryName(dbPath);
            if (!string.IsNullOrEmpty(dbDirectory) && !System.IO.Directory.Exists(dbDirectory))
            {
                System.IO.Directory.CreateDirectory(dbDirectory);
            }

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
