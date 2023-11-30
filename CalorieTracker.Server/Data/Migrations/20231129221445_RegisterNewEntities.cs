using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RegisterNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diaries",
                columns: table => new
                {
                    DiaryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diaries", x => x.DiaryId);
                    table.ForeignKey(
                        name: "FK_Diaries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    MealTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.MealTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FoodDiaries",
                columns: table => new
                {
                    FoodDiaryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiaryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MealTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiaries", x => x.FoodDiaryId);
                    table.ForeignKey(
                        name: "FK_FoodDiaries_Diaries_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Diaries",
                        principalColumn: "DiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Protein = table.Column<double>(type: "REAL", nullable: false),
                    Carbs = table.Column<double>(type: "REAL", nullable: false),
                    Fat = table.Column<double>(type: "REAL", nullable: false),
                    Calories = table.Column<double>(type: "REAL", nullable: false),
                    FoodDiaryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_FoodDiaries_FoodDiaryId",
                        column: x => x.FoodDiaryId,
                        principalTable: "FoodDiaries",
                        principalColumn: "FoodDiaryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diaries_UserId",
                table: "Diaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_DiaryId",
                table: "FoodDiaries",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_FoodId",
                table: "FoodDiaries",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodDiaryId",
                table: "Foods",
                column: "FoodDiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodDiaries_Foods_FoodId",
                table: "FoodDiaries",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodDiaries_Diaries_DiaryId",
                table: "FoodDiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodDiaries_Foods_FoodId",
                table: "FoodDiaries");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "Diaries");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "FoodDiaries");
        }
    }
}
