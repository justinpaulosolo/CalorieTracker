using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFoodNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodDiaries_Foods_FoodId",
                table: "FoodDiaries");

            migrationBuilder.DropIndex(
                name: "IX_FoodDiaries_FoodId",
                table: "FoodDiaries");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "FoodDiaries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "FoodDiaries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_FoodId",
                table: "FoodDiaries",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodDiaries_Foods_FoodId",
                table: "FoodDiaries",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
