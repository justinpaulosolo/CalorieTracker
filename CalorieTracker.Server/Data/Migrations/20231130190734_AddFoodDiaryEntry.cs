using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodDiaries_FoodDiaryId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_FoodDiaryId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodDiaryId",
                table: "Foods");

            migrationBuilder.CreateTable(
                name: "FoodDiaryEntries",
                columns: table => new
                {
                    FoodDiaryEntryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FoodDiaryId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiaryEntries", x => x.FoodDiaryEntryId);
                    table.ForeignKey(
                        name: "FK_FoodDiaryEntries_FoodDiaries_FoodDiaryId",
                        column: x => x.FoodDiaryId,
                        principalTable: "FoodDiaries",
                        principalColumn: "FoodDiaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodDiaryEntries_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaryEntries_FoodDiaryId",
                table: "FoodDiaryEntries",
                column: "FoodDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaryEntries_FoodId",
                table: "FoodDiaryEntries",
                column: "FoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodDiaryEntries");

            migrationBuilder.AddColumn<int>(
                name: "FoodDiaryId",
                table: "Foods",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodDiaryId",
                table: "Foods",
                column: "FoodDiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodDiaries_FoodDiaryId",
                table: "Foods",
                column: "FoodDiaryId",
                principalTable: "FoodDiaries",
                principalColumn: "FoodDiaryId");
        }
    }
}
