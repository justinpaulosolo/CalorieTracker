using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class FoodItemColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Proteins",
                table: "FoodItems",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "Fats",
                table: "FoodItems",
                newName: "Fat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "FoodItems",
                newName: "Proteins");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "FoodItems",
                newName: "Fats");
        }
    }
}
