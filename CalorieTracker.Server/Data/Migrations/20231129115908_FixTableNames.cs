using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProteinGoal",
                table: "MacrosGoals",
                newName: "ProteinsGoal");

            migrationBuilder.RenameColumn(
                name: "CarbsGoal",
                table: "MacrosGoals",
                newName: "CarbohydratesGoal");

            migrationBuilder.RenameColumn(
                name: "Carbs",
                table: "FoodItems",
                newName: "Carbohydrates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProteinsGoal",
                table: "MacrosGoals",
                newName: "ProteinGoal");

            migrationBuilder.RenameColumn(
                name: "CarbohydratesGoal",
                table: "MacrosGoals",
                newName: "CarbsGoal");

            migrationBuilder.RenameColumn(
                name: "Carbohydrates",
                table: "FoodItems",
                newName: "Carbs");
        }
    }
}
