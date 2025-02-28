using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroMateApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CalorieGoal = table.Column<double>(type: "REAL", nullable: false),
                    ProteinGoal = table.Column<double>(type: "REAL", nullable: false),
                    CarbGoal = table.Column<double>(type: "REAL", nullable: false),
                    FatGoal = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGoals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGoals");
        }
    }
}
