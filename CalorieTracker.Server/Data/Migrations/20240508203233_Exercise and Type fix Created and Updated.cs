using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseandTypefixCreatedandUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "ExerciseId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ExerciseTypes",
                keyColumn: "ExerciseTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
