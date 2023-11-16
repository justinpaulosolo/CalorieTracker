using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations;

/// <inheritdoc />
public partial class MacroGoals : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MacrosGoals",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                UserId = table.Column<string>(type: "TEXT", nullable: false),
                ProteinGoal = table.Column<int>(type: "INTEGER", nullable: false),
                CarbsGoal = table.Column<int>(type: "INTEGER", nullable: false),
                FatsGoal = table.Column<int>(type: "INTEGER", nullable: false),
                CaloriesGoal = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MacrosGoals", x => x.Id);
                table.ForeignKey(
                    name: "FK_MacrosGoals_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MacrosGoals_UserId",
            table: "MacrosGoals",
            column: "UserId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MacrosGoals");
    }
}
