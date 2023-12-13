using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditSavedFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedFoods_AspNetUsers_ApplicationUserId",
                table: "SavedFoods");

            migrationBuilder.DropIndex(
                name: "IX_SavedFoods_ApplicationUserId",
                table: "SavedFoods");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SavedFoods");

            migrationBuilder.CreateIndex(
                name: "IX_SavedFoods_UserId",
                table: "SavedFoods",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedFoods_AspNetUsers_UserId",
                table: "SavedFoods",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedFoods_AspNetUsers_UserId",
                table: "SavedFoods");

            migrationBuilder.DropIndex(
                name: "IX_SavedFoods_UserId",
                table: "SavedFoods");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SavedFoods",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedFoods_ApplicationUserId",
                table: "SavedFoods",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedFoods_AspNetUsers_ApplicationUserId",
                table: "SavedFoods",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
