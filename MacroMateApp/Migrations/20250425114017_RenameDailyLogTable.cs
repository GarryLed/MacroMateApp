using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroMateApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameDailyLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_DailyLog_DailyLogId",
                table: "FoodItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyLog",
                table: "DailyLog");

            migrationBuilder.RenameTable(
                name: "DailyLog",
                newName: "DailyLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyLogs",
                table: "DailyLogs",
                column: "DailyLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_DailyLogs_DailyLogId",
                table: "FoodItems",
                column: "DailyLogId",
                principalTable: "DailyLogs",
                principalColumn: "DailyLogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_DailyLogs_DailyLogId",
                table: "FoodItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyLogs",
                table: "DailyLogs");

            migrationBuilder.RenameTable(
                name: "DailyLogs",
                newName: "DailyLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyLog",
                table: "DailyLog",
                column: "DailyLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_DailyLog_DailyLogId",
                table: "FoodItems",
                column: "DailyLogId",
                principalTable: "DailyLog",
                principalColumn: "DailyLogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
