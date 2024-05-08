using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixExercisetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseTypes_ExerciseTypeId",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_ExerciseTypeId",
                table: "Exercises",
                newName: "IX_Exercises_ExerciseTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "ExerciseId");

            migrationBuilder.UpdateData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(1980), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2040) });

            migrationBuilder.UpdateData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2050), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2070), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2070) });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2070), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2070) });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2080), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2080) });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2080), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2080) });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2080), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2090), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2090), new DateTime(2024, 5, 8, 13, 38, 5, 637, DateTimeKind.Local).AddTicks(2090) });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "ExerciseTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_ExerciseTypeId",
                table: "Exercise",
                newName: "IX_Exercise_ExerciseTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "ExerciseId");

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(600), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(600), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(520), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(580), new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(580) });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseTypes_ExerciseTypeId",
                table: "Exercise",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "ExerciseTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
