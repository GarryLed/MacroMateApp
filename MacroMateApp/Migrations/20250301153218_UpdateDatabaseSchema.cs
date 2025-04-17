using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroMateApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CalorieGoal",
                table: "UserGoals",
                newName: "CaloriesGoal");

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodLog");

            migrationBuilder.RenameColumn(
                name: "CaloriesGoal",
                table: "UserGoals",
                newName: "CalorieGoal");
        }
    }
}
