using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseDiary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseDiaries",
                columns: table => new
                {
                    ExerciseDiaryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiaryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDiaries", x => x.ExerciseDiaryId);
                    table.ForeignKey(
                        name: "FK_ExerciseDiaries_Diaries_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Diaries",
                        principalColumn: "DiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDiaryEntries",
                columns: table => new
                {
                    ExerciseDiaryEntryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExerciseDiaryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExerciseTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDiaryEntries", x => x.ExerciseDiaryEntryId);
                    table.ForeignKey(
                        name: "FK_ExerciseDiaryEntries_ExerciseDiaries_ExerciseDiaryId",
                        column: x => x.ExerciseDiaryId,
                        principalTable: "ExerciseDiaries",
                        principalColumn: "ExerciseDiaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseDiaryEntries_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "ExerciseTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDiaries_DiaryId",
                table: "ExerciseDiaries",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDiaryEntries_ExerciseDiaryId",
                table: "ExerciseDiaryEntries",
                column: "ExerciseDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDiaryEntries_ExerciseTypeId",
                table: "ExerciseDiaryEntries",
                column: "ExerciseTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseDiaryEntries");

            migrationBuilder.DropTable(
                name: "ExerciseDiaries");
        }
    }
}
